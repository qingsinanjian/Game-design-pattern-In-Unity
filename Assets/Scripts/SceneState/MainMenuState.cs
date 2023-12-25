using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateController controller) : base("02MainMenuScene", controller)
    {
    }

    public override void StateStart()
    {
        GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        m_SceneController.SetState(new BattleState(m_SceneController));
    }
}
