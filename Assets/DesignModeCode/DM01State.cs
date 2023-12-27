using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM01State : MonoBehaviour
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
    private IState mstate;//m´ú±ímember
    public void SetState(IState state)
    {
        mstate = state;
    }

    public void Handle(int arg)
    {
        mstate.Handle(arg);
    }
}

public interface IState
{
    void Handle(int args);
}

public class ConcreteStateA : IState
{
    private Contex mContex;
    public ConcreteStateA(Contex contex)
    {
        mContex = contex;
    }

    public void Handle(int args)
    {
        Debug.Log("ConcreteStateA.Handle " + args);
        if(args > 10)
        {
            mContex.SetState(new ConcreteStateB(mContex));
        }
    }
}

public class ConcreteStateB : IState
{
    private Contex mContex;
    public ConcreteStateB(Contex contex)
    {
        mContex = contex;
    }
    public void Handle(int args)
    {
        Debug.Log("ConcreteStateB.Handle " + args);
        if((args <= 10))
        {
            mContex.SetState(new ConcreteStateA(mContex));
        }
    }
}
