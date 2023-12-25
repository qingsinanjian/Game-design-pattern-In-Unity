using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState
{
    public StartState(SceneStateController controller) : base("01StartScene", controller)
    {
    }

    private Image m_logo;
    private float mSmoothingSpeed = 0.5f;
    private float mWaitTime = 2;

    public override void StateStart()
    {
        m_logo = GameObject.Find("Logo").GetComponent<Image>();
        m_logo.color = Color.black;
    }

    public override void StateUpdate()
    {
        m_logo.color = Color.Lerp(m_logo.color, Color.white, mSmoothingSpeed * Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if(mWaitTime < 0)
        {
            m_SceneController.SetState(new MainMenuState(m_SceneController));
        }
    }
}
