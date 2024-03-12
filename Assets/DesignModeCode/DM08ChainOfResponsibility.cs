using System;
using System.Collections.Generic;
using UnityEngine;

public class DM08ChainOfResponsibility : MonoBehaviour
{
    private void Start()
    {
        char problem = 'c';
        //switch (problem)
        //{
        //    case 'a':
        //        new DMHandlerA().Handle();
        //        break;
        //    case 'b':
        //        new DMHandlerA().Handle();
        //        break;
        //    default:
        //        break;
        //}

        DMHandlerA handlerA = new DMHandlerA();
        DMHandlerB handlerB = new DMHandlerB();
        DMHandlerC handlerC = new DMHandlerC();
        //handlerA.nextHandler = handlerB;
        handlerA.SetNextHandler(handlerB).SetNextHandler(handlerC);
        handlerA.Handle(problem);
    }
}

public abstract class IDMHandler
{
    protected IDMHandler mNextHandler = null;
    public IDMHandler nextHandler
    {
        set { mNextHandler = value; }
    }

    public IDMHandler SetNextHandler(IDMHandler handler)
    {
        mNextHandler = handler;
        return handler;
    }

    public virtual void Handle(char problem) { }
}

class DMHandlerA : IDMHandler
{
    public override void Handle(char problem)
    {
        if(problem == 'a')
        {
            Debug.Log("处理完了A问题");
        }
        else
        {
            if(mNextHandler != null)
            {
                mNextHandler.Handle(problem);
            }
        }
    }
}

class DMHandlerB : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'b')
        {
            Debug.Log("处理完了B问题");
        }
        else
        {
            if (mNextHandler != null)
            {
                mNextHandler.Handle(problem);
            }
        }
    }
}

class DMHandlerC: IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'c')
        {
            Debug.Log("处理完了C问题");
        }
        else
        {
            if (mNextHandler != null)
            {
                mNextHandler.Handle(problem);
            }
        }
    }
}

