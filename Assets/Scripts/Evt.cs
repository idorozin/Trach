using System;
using UnityEngine;

public class Evt<T>
{

    private Action<T> action = delegate {  };

    public void Invoke(T param)
    {
        action.Invoke(param);
    }

    public void Subscribe(Action<T> action)
    {
        this.action += action;
    }

    public void UnSubscribe(Action<T> action)
    {
        this.action -= action;
    }
    
}
public class Evt
{

    private Action action = delegate {  };

    public void Invoke()
    {
        action.Invoke();
    }

    public void Subscribe(Action action)
    {
        this.action += action;
    }

    public void UnSubscribe(Action action)
    {
        this.action -= action;
    }
    
}