using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon
{
    protected int mAtk;
    protected float mAtkRange;
    protected int mAtkPlusValue;

    protected GameObject mGameObject;
    protected ICharacter mOwner;

    protected ParticleSystem mParticle;
    protected LineRenderer mLineRenderer;
    protected Light mLight;
    protected AudioSource mAudio;

    public abstract void Fire(Vector3 targetPoisition);
}
