using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDesignMode : MonoBehaviour
{
    private void Start()
    {
        Contex contex = new Contex();
        contex.SetState(new ConcreteStateA(contex));
        contex.Handle(5);
        contex.Handle(20);
        contex.Handle(30);
        contex.Handle(4);
        contex.Handle(6);
    }
}

public class Contex
{
    private IState m_state;//m´ú±ímember
    public void SetState(IState state)
    {
        m_state = state;
    }

    public void Handle(int arg)
    {
        m_state.Handle(arg);
    }
}

public interface IState
{
    void Handle(int args);
}

public class ConcreteStateA : IState
{
    private Contex m_contex;
    public ConcreteStateA(Contex contex)
    {
        m_contex = contex;
    }

    public void Handle(int args)
    {
        Debug.Log("ConcreteStateA.Handle " + args);
        if(args > 10)
        {
            m_contex.SetState(new ConcreteStateB(m_contex));
        }
    }
}

public class ConcreteStateB : IState
{
    private Contex m_contex;
    public ConcreteStateB(Contex contex)
    {
        m_contex = contex;
    }
    public void Handle(int args)
    {
        Debug.Log("ConcreteStateB.Handle " + args);
        if((args <= 10))
        {
            m_contex.SetState(new ConcreteStateA(m_contex));
        }
    }
}
