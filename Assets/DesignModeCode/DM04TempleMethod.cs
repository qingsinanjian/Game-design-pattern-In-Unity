using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DM04TempleMethod : MonoBehaviour
{
    private void Start()
    {
        //IPeople people = new SouthPeople();
        IPeople people = new NorthPeople();
        people.Eat();
    }
}

public abstract class IPeople
{
    public void Eat()
    {
        OrderFoods();
        EatSomthing();
        PayBill();
    }

    private void OrderFoods()
    {
        Debug.Log("点单");
    }

    protected virtual void EatSomthing()
    {

    }

    private void PayBill()
    {
        Debug.Log("买单");
    }
}

public class NorthPeople : IPeople
{
    protected override void EatSomthing()
    {
        Debug.Log("吃面条");
    }
}

public class SouthPeople : IPeople
{
    protected override void EatSomthing()
    {
        Debug.Log("吃米饭");
    }
}
