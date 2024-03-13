using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameEventObserver
{
    public abstract void Update();
    public abstract void SetSubject(IGameEventSubject subject);
}

