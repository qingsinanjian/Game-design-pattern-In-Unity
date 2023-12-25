using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ISceneState
{
    private string m_SceneName;
    protected SceneStateController m_SceneController;

    public ISceneState(string sceneName, SceneStateController controller)
    {
        m_SceneName = sceneName;
        m_SceneController = controller;
    }

    public string SceneName
    {
        get { return m_SceneName; }
    }

    //每次进入状态时调用
    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}

