using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTween : Tween
{
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _direction;
    private Func<float, float> EaseMethod;
    
    private float _speed;
    private float _percent;

    public PositionTween(GameObject objectToMove, Vector3 targetPosition, float speed, Func<float, float> Method) : base(objectToMove)
    {
        _targetPosition = targetPosition;
        _startPosition = _gameObject.transform.position;
        _direction = _targetPosition - _startPosition;
        EaseMethod = Method;
        this._speed = speed;
    }

  protected override void StartTween()
    {
        Debug.Log("Tween Started");

        this.active = true;
    }

    protected override void PerformTween()
    {
        Debug.Log("Updating tween");
        _percent += Time.deltaTime / _speed;
        
        if (_percent < 1) {
            float easeStep = EaseMethod(_percent);
            _gameObject.transform.position = _startPosition + (_direction * easeStep);
        } 
        else
        {
            this.LogicIsOver = true;
        }
    }

    protected override void TweenEnd()
    {
        Debug.Log("Ending tween");
        this.active = false;
    }
}
