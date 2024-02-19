using System;
using System.Collections.Generic;
using UnityEngine;

public class DM05Builder : MonoBehaviour
{
    private void Start()
    {
        IBuilder fatPersonBuilder = new FatPersonBuilder();
        IBuilder thinPersonBuilder = new ThinPersonBuilder();

        Person fatPerson = Director.Construct(fatPersonBuilder);
        fatPerson.Show();
    }
}

class Person
{
    List<string> parts = new List<string>();
    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        foreach (string part in parts)
        {
            Debug.Log(part);
        }
    }

}

class FatPerson : Person
{

}

class ThinPerson : Person
{

}

interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddHand();
    void AddFeet();
    Person GetResult();
}

class FatPersonBuilder : IBuilder
{
    private Person person;

    public FatPersonBuilder()
    {
        person = new FatPerson();
    }

    public void AddBody()
    {
        person.AddPart("胖人身体");
    }

    public void AddFeet()
    {
        person.AddPart("胖人脚");
    }

    public void AddHand()
    {
        person.AddPart("胖人手");
    }

    public void AddHead()
    {
        person.AddPart("胖人头");
    }

    public Person GetResult()
    {
        return person;
    }
}

class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new ThinPerson();
    }

    public void AddBody()
    {
        person.AddPart("瘦人身体");
    }

    public void AddFeet()
    {
        person.AddPart("瘦人脚");
    }

    public void AddHand()
    {
        person.AddPart("瘦人手");
    }

    public void AddHead()
    {
        person.AddPart("瘦人头");
    }

    public Person GetResult()
    {
        return person;
    }
}

class Director
{
    public static Person Construct(IBuilder builder)
    {
        builder.AddBody();
        builder.AddHead();
        builder.AddHand();
        builder.AddFeet();
        return builder.GetResult();
    }
}

