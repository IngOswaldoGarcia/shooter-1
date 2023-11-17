using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker instance;
    private Animator cameraAnimator;

    void Awake()
    {
        if(CameraShaker.instance == null){
            CameraShaker.instance = this;
        }else if (CameraShaker.instance != this){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
    }
    
    public void CameraShake(){
        cameraAnimator.SetTrigger("PlayShake");
    }

    void OnDestroy()
    {
        if(CameraShaker.instance == this){
            CameraShaker.instance = null;
        }
    }
}
