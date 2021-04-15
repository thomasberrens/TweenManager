using System;
using UnityEngine;

public class RotateTween : Tween
{
    public RotateTween(GameObject objectToTween) : base(objectToTween)
    {
        
    }

    protected override void StartTween()
    {
        Debug.Log("Start rotate tween");
        this.active = true;
    }

    protected override void PerformTween()
    {
        Debug.Log("Update rotate tween");

        _gameObject.transform.Rotate(45.0f, 45f, 45f);
        this.LogicIsOver = true;

    }

    protected override void TweenEnd()
    {
        Debug.Log("End rotate tween");
        this.active = false;
    }
}