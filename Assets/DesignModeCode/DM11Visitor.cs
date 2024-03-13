using System;
using System.Collections.Generic;
using UnityEngine;

public class DM11Visitor : MonoBehaviour
{
    private void Start()
    {
        DMSphere shere1 = new DMSphere();
        DMCylinder cylinder1 = new DMCylinder();
        DMCube cube1 = new DMCube();
        DMCube cube2 = new DMCube();

        DMShapeContainer mShapeContainer = new DMShapeContainer();
        mShapeContainer.AddShape(shere1);
        mShapeContainer.AddShape(cylinder1);
        mShapeContainer.AddShape(cube1);
        mShapeContainer.AddShape(cube2);

        //int count = mShapeContainer.GetShapeCount();
        //int cubeCount = mShapeContainer.GetCubeCount();

        AmountVisitor amountVisitor = new AmountVisitor();
        mShapeContainer.RunVisitor(amountVisitor);
        int amount = amountVisitor.amount;
        Debug.Log("图形总数：" + amount);

        CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
        mShapeContainer.RunVisitor(cubeAmountVisitor);
        int cubeAmount = cubeAmountVisitor.amount;
        Debug.Log("Cube总数：" + cubeAmount);

        EdgeVisitor edgeVisitor = new EdgeVisitor();
        mShapeContainer.RunVisitor(edgeVisitor);
        int edgeAmount = edgeVisitor.amount;
        Debug.Log("边总数：" + edgeAmount);
    }
}

class DMShapeContainer
{
    private List<IDMShape> mShapes = new List<IDMShape>();

    public void AddShape(IDMShape shape)
    {
        mShapes.Add(shape);
    }

    public void RunVisitor(IShapeVisitor visitor)
    {
        foreach (IDMShape shape in mShapes)
        {
            shape.RunVisitor(visitor);
        }
    }

    //public int GetShapeCount()
    //{
    //    return mShapes.Count;
    //}

    //public int GetCubeCount()
    //{
    //    int count = 0;
    //    foreach(IDMShape shape in mShapes)
    //    {
    //        if(shape.GetType() == typeof(DMCube))
    //        {
    //            count++;
    //        }
    //    }
    //    return count;
    //}

    //public int GetVolume()
    //{
    //    int temp = 0;
    //    foreach (IDMShape shape in mShapes)
    //    {
    //        temp += shape.GetVolume();
    //    }
    //    return temp;
    //}
}

abstract class IDMShape
{
    //public abstract int GetVolume();
    public abstract void RunVisitor(IShapeVisitor visitor);
}

class DMSphere : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 30;
    //}
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}

class DMCylinder : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 20;
    //}
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}

class DMCube : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 10;
    //}
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

abstract class IShapeVisitor
{
    public abstract void VisitSphere(DMSphere sphere);
    public abstract void VisitCylinder(DMCylinder cylinder);
    public abstract void VisitCube(DMCube cube);
}

class AmountVisitor : IShapeVisitor
{
    public int amount = 0;

    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount++;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        amount++;
    }
}

class CubeAmountVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        
    }

    public override void VisitSphere(DMSphere sphere)
    {
        
    }
}

class EdgeVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount += 12;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount += 2;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        amount += 1;
    }
}

