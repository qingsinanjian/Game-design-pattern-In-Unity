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
                Debug.LogError("mGameObjectÎª¿Õ");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }

    public float GetAtkRange()
    {
        return mWeapon.AtkRange;
    }

    public void Attack(ICharacter target)
    {
        if (mWeapon != null)
        {
            mWeapon.Fire(target.Position);
        }
    }

    public void PlayAnim(string aniName)
    {
        mAnimation.CrossFade(aniName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
    }

}
