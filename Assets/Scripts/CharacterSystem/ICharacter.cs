using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected Animation mAnimation;
    protected IWeapon mWeapon;

    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    protected float mDestroyTimer = 2f;
    public IWeapon weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.owner = this;
            GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
            UnityTool.Attach(child, mWeapon.gameObject);
        }
        get
        {
            return mWeapon;
        }
    }

    public ICharacterAttr attr { set { mAttr = value; } get { return mAttr; } }

    public Vector3 Position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }

    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnimation = mGameObject.GetComponentInChildren<Animation>();
        }

        get
        {
            return mGameObject;
        }
    }

    public bool canDestroy
    {
        get { return mCanDestroy; }
    }

    public bool isKilled { get { return mIsKilled; } }

    public float GetAtkRange()
    {
        return mWeapon.atkRange;
    }

    public void Update()
    {
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if(mDestroyTimer <= 0)
            {
                mCanDestroy = true;
            }
        }
        mWeapon.Update();
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);

    public abstract void RunVisitor(ICharacterVisitor visitor);

    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.atk + mAttr.critValue);
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
        //被攻击的效果 音效 视效 只有敌人有

        //死亡效果 音效 视效 只有战士有
    }

    public virtual void Killed()
    {
        mIsKilled = true;
        mNavAgent.isStopped = true;
    }

    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }

    public void PlayAnim(string aniName)
    {
        mAnimation.CrossFade(aniName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
        PlayAnim("move");
    }
    protected void DoPlayEffect(string effectName)
    {
        //第一步 加载特效 TODO
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectName);
        effectGO.transform.position = Position;
        //控制销毁 TODO
        effectGO.AddComponent<DestroyForTime>();
    }
    public void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }

}
