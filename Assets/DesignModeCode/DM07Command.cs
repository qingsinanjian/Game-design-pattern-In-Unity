﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class DM07Command : MonoBehaviour
{
    private void Start()
    {
        DMInvoker invoker = new DMInvoker();
        ConcreteCommand1 cmd1 = new ConcreteCommand1(new DMReceiver1());
        invoker.AddCommand(cmd1);
        invoker.ExecuteCommand();
    }
}

public class DMInvoker
{
    private List<DMICommand> commands = new List<DMICommand>();

    public void AddCommand(DMICommand command)
    {
        commands.Add(command);
    }

    public void ExecuteCommand()
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
        commands.Clear();
    }
}

public abstract class DMICommand
{
    public abstract void Execute();
}

public class ConcreteCommand1 : DMICommand
{
    DMReceiver1 receiver1;
    public ConcreteCommand1(DMReceiver1 receiver1)
    {
        this.receiver1 = receiver1;
    }
    public override void Execute()
    {
        receiver1.Action("Command1");
    }
}

public class DMReceiver1
{
    public void Action(string cmd)
    {
        Debug.Log($"Receiver1执行了命令{cmd}");
    }
}

