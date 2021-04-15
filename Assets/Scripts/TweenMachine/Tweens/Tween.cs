using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Tween
{
    protected GameObject _gameObject;
    
    protected bool active;

    protected bool LogicIsOver;
    
    public Tween(GameObject objectToTween)
    {
        _gameObject = objectToTween;
        
        StartTween();
    }

    public void UpdateTween()
    {
        
        if (LogicIsOver)
        {
            TweenEnd();
        }
        
        if (active) {
            
            PerformTween();
        }
    }

    public bool isActive()
    {
        return this.active;
    }

    protected abstract void StartTween();
    protected abstract void PerformTween();
    protected abstract void TweenEnd();
}