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
        Debug.Log("�㵥");
    }

    protected virtual void EatSomthing()
    {

    }

    private void PayBill()
    {
        Debug.Log("��");
    }
}

public class NorthPeople : IPeople
{
    protected override void EatSomthing()
    {
        Debug.Log("������");
    }
}

public class SouthPeople : IPeople
{
    protected override void EatSomthing()
    {
        Debug.Log("���׷�");
    }
}
