using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    protected float mEffectDisplayTime;

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
        //显示枪口特效
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 targetPoisition);

    protected void DoPlayBulletEffect(float width, Vector3 targetPoisition)
    {
        //显示子弹轨迹特效
        mLineRenderer.enabled = true;
        mLineRenderer.startWidth = width;
        mLineRenderer.endWidth = width;
        mLineRenderer.SetPosition(0, mGameObject.transform.position);
        mLineRenderer.SetPosition(1, targetPoisition);
    }

    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName)
    {
        //播放声音
        AudioClip clip = null;//TODO
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect()
    {
        mLight.enabled = false;
        mLineRenderer.enabled = false;
    }
}
