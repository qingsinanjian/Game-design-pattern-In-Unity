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
    public IWeapon weapon { set { mWeapon = value; } }

    public Vector3 Position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObjectΪ��");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }

    public float GetAtkRange()
    {
        return mWeapon.AtkRange;
    }

    public void Update()
    {
        mWeapon.Update();
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);

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
        //��������Ч�� ��Ч ��Ч ֻ�е�����

        //����Ч�� ��Ч ��Ч ֻ��սʿ��
    }

    public void Killed()
    {
        //TODO
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
        //��һ�� ������Ч TODO
        GameObject effectGO;
        //�������� TODO
    }
    public void DoPlaySound(string soundName)
    {
        AudioClip clip = null;//TODO
        mAudio.clip = clip;
        mAudio.Play();
    }

}
