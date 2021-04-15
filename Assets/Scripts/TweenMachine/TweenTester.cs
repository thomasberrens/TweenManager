using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;

    public EaseTypes easeType;
    public TweenTypes tweenTypes;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (tweenTypes)
            {
               case TweenTypes.PositionTween:
                   handlePositionTween();
                   break;
               case TweenTypes.RotateTween:
                   handleRotateTween();
                   break;
               case TweenTypes.ScaleTween:
                   handleScaleTween();
                   break;
            }
        }
    }

    private void handleRotateTween()
    {
        TweenMachine.RotateGameObject(gameObject);
    }

    private void handleScaleTween()
    {
        TweenMachine.ScaleGameObject(gameObject);
    }

    private void handlePositionTween()
    {
        switch (easeType)
        {
            case EaseTypes.Linear: 
                TweenMachine.MoveGameObject(gameObject, targetPosition, speed, Easings.Linear);
                //   FindObjectOfType<GameObject>().GetComponent<TweenMachine>().MoveGameObject();
                break;
                
            case EaseTypes.EaseInQuad: 
                TweenMachine.MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuad);
                break;
                
            case EaseTypes.EaseInCubic:
                TweenMachine.MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInCubic);
                break;
                
            case EaseTypes.EaseInQuart:
                TweenMachine.MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuart);
                break;
                
            case EaseTypes.EaseInQuint:
                TweenMachine.MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                break;
            case EaseTypes.EaseInBack:
                TweenMachine.MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInBack);
                break;
        }
    }
}
