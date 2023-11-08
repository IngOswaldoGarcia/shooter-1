using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _positionStrength;
    [SerializeField] private Vector3 _rotationStrength;

    private static event Action Shake;

    public static void Invoke(){
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShake;
    private void OnDisable() => Shake -= CameraShake;
    
    private void CameraShake(){
        Debug.Log("CameraShake method called");
        _camera.DOComplete();
        _camera.DOShakePosition(1f, _positionStrength);
        _camera.DOShakeRotation(1f, _rotationStrength);
    }
}
