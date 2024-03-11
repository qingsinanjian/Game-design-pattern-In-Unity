using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket,
    MAX
}

public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;
    //protected int mAtkPlusValue;

    protected GameObject mGameObject;
    protected ICharacter mOwner;

    protected ParticleSystem mParticle;
    protected LineRenderer mLineRenderer;
    protected Light mLight;
    protected AudioSource mAudio;

    protected float mEffectDisplayTime;

    public float atkRange
    {
        get
        {
            return mBaseAttr.atkRange;
        }
    }

    public int atk
    {
        get { return mBaseAttr.atk; }
    }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;
        Transform effect = mGameObject.transform.Find("Effect");
        mParticle = effect.GetComponent<ParticleSystem>();
        mLineRenderer = mParticle.GetComponent<LineRenderer>();
        mLight = mParticle.GetComponent<Light>();
        mAudio = mParticle.GetComponent<AudioSource>();
    }

    public ICharacter owner
    {
        set { mOwner = value; }
    }

    public GameObject gameObject
    {
        get { return mGameObject; }
    }

    public void Update()
    {
        if(mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if(mEffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    public void Fire(Vector3 targetPoisition)
    {
        PlayMuzzleEffect();
        PlayBulletEffect(targetPoisition);
        PlaySound();
    }

    protected abstract void SetEffectDisplayTime();

    protected virtual void PlayMuzzleEffect()
    {
        //��ʾǹ����Ч
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 targetPoisition);

    protected void DoPlayBulletEffect(float width, Vector3 targetPoisition)
    {
        //��ʾ�ӵ��켣��Ч
        mLineRenderer.enabled = true;
        mLineRenderer.startWidth = width;
        mLineRenderer.endWidth = width;
        mLineRenderer.SetPosition(0, mGameObject.transform.position);
        mLineRenderer.SetPosition(1, targetPoisition);
    }

    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName)
    {
        //��������
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect()
    {
        mLight.enabled = false;
        mLineRenderer.enabled = false;
    }
}
