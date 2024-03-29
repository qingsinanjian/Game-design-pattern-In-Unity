﻿using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DM06Composite : MonoBehaviour
{
    private void Start()
    {
        DMComposite root = new DMComposite("Root");
        DMLeaf leaf1 = new DMLeaf("GameObject");
        DMLeaf leaf2 = new DMLeaf("GameObject (2)");
        DMComposite gameObject1 = new DMComposite("GameObject (1)");
        root.AddChild(leaf1);
        root.AddChild(gameObject1);
        root.AddChild(leaf2);

        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject (1)");
        gameObject1.AddChild(child1);
        gameObject1.AddChild(child2);
        ReadComponent(root);
    }
    
    private void ReadComponent(DMComponent component)
    {
        Debug.Log(component.name);
        List<DMComponent> children = component.children;
        if (children == null || children.Count == 0) return;
        foreach (DMComponent child in children)
        {
            ReadComponent(child);
        }
    }
}

public abstract class DMComponent
{
    protected string nName;
    public string name {  get { return nName;} }
    protected List<DMComponent> mChildren;
    public List<DMComponent> children {  get { return mChildren; } }
    public DMComponent(string name)
    {
        nName = name;
        mChildren = new List<DMComponent>();
    }

    public abstract void AddChild(DMComponent c);
    public abstract void RemoveChild(DMComponent c);
    public abstract DMComponent GetChild(int index);
}

public class DMLeaf : DMComponent
{
    public DMLeaf(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        return;
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }

    public override void RemoveChild(DMComponent c)
    {
        return;
    }
}

public class DMComposite : DMComponent
{
    public DMComposite(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        mChildren.Add(c);
    }

    public override DMComponent GetChild(int index)
    {
       return mChildren[index];
    }

    public override void RemoveChild(DMComponent c)
    {
        mChildren.Remove(c);
    }
}

