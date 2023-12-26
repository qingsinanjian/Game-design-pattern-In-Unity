using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade
{
    private static GameFacade _instance = new GameFacade();
    public static GameFacade Instance
    {
        get { return _instance; }
    }

    private GameFacade() { }

    private bool mIsGameOver = false;

    public bool IsGameOver
    {
        get { return mIsGameOver; }
    }

    public void Init()
    {

    }

    public void Update()
    {
        
    }

    public void Release()
    {

    }
}
