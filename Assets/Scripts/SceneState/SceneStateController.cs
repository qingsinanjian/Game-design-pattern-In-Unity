using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private ISceneState m_sceneState;
    private AsyncOperation m_AO;
    private bool m_IsRunStart;

    public void SetState(ISceneState sceneState, bool isLoadScene = true)
    {
        if(m_sceneState != null)
        {
            m_sceneState.StateEnd();//让上一个场景做一下清理工作
        }
        m_sceneState = sceneState;
        if (isLoadScene)
        {
            m_AO = SceneManager.LoadSceneAsync(m_sceneState.SceneName);
            m_IsRunStart = false;
        }
        else
        {
            m_sceneState.StateStart();
            m_IsRunStart = true;
        }

    }

    public void StateUpdate()
    {
        if(m_AO != null && m_AO.isDone == false)
        {
            return;
        }

        if (m_AO != null)
        {
            if (m_AO.isDone && m_IsRunStart == false)
            {
                m_sceneState.StateStart();
                m_IsRunStart = true;
            }
        }

        if (m_sceneState != null)
        {
            m_sceneState.StateUpdate();
        }
    }
}