using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TweenMachine : MonoBehaviour
{
    
    /*
     * DIT PROJECT IS GEMAAKT DOOR THOMAS BERRENS EN DEAN HENDRIKS
     */
    
    private static List<Tween> _activeTweens = new List<Tween>();

    private bool paused;
    private static GameObject TweenMachineGO;

    private void Update()
    {
        if (_activeTweens.Count <= 0)
        {
            Destroy(gameObject);
            return;
        }

        foreach (Tween _activeTween in _activeTweens.ToList())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pausing tweens: " + !this.paused);
                TogglePauseTweens();
            }
            if (paused) continue;
            if (HandleEndOfTween(_activeTween)) continue;

            _activeTween.UpdateTween();
        }
    }

    public static void MoveGameObject(GameObject objectToMove, Vector3 targetPosition, float speed, Func<float, float> EaseMethod)
    {
        Init();
        
        PositionTween tween = new PositionTween(objectToMove, targetPosition, speed, EaseMethod);

        _activeTweens.Add(tween);
    }

    public static void RotateGameObject(GameObject gameObject)
    {
        Init();
        RotateTween tween = new RotateTween(gameObject);
        _activeTweens.Add(tween);
    }

    public static void ScaleGameObject(GameObject gameObject)
    {
        Init();
        ScaleTween tween = new ScaleTween(gameObject);
        _activeTweens.Add(tween);
    }
    

    private static void Init()
    {
        if (TweenMachineGO != null) return;
       // Debug.Log("Need tweenmachine! Creating one");

        TweenMachineGO = new GameObject("TweenMachine");
        TweenMachineGO.AddComponent<TweenMachine>();
    }

    private bool isTweenOver(Tween tween)
    {
        return !tween.isActive();
    }

    private void RemoveTween(Tween tween)
    {
        _activeTweens.Remove(tween);
    }

    private void TogglePauseTweens()
    {
        this.paused = !this.paused;
    }

    private bool HandleEndOfTween(Tween tween)
    {
        if (isTweenOver(tween))
        {
            RemoveTween(tween);
            return true;
        }

        return false;
    }
}