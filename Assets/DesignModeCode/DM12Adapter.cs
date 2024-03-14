using System;
using System.Collections.Generic;
using UnityEngine;

public class DM12Adapter : MonoBehaviour
{
    private void Start()
    {
        //StandardInterface si = new StandardImplementA();
        //si.Request();
        Adapter adapter = new Adapter(new NewPlugin());
        StandardInterface si = adapter;
        si.Request();
    }
}

interface StandardInterface
{
    void Request();
}

class StandardImplementA : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法实现");
    }
}

class Adapter : StandardInterface
{
    private NewPlugin plugin;
    public Adapter(NewPlugin plugin)
    {
        this.plugin = plugin;
    }
    public void Request()
    {
        plugin.SpecificRequest();
    }
}

class NewPlugin
{
    public void SpecificRequest()
    {
        Debug.Log("使用特殊的插件方法实现请求");
    }
}

