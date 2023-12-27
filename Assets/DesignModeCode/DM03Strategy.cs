using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM03Strategy : MonoBehaviour
{
    private void Start()
    {
        StrategyContext context = new StrategyContext();
        context.strategy = new ConcreteStrategyB();
        context.Cal();
    }
}

public class StrategyContext
{
    public IStrategy strategy;
    public void Cal()
    {
        strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}

public class ConcreteStrategyA : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用A策略计算");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用B策略计算");
    }
}
