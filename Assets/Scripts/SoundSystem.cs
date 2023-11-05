using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{

    public static SoundSystem instance;
    // Start is called before the first frame update
    public AudioClip audioShoot;
    public AudioSource audioSource;

    void Awake()
    {
        if(SoundSystem.instance == null){
            SoundSystem.instance = this;
        }else if (SoundSystem.instance != this){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(){
        audioSource.PlayOneShot(audioShoot, 1.541F);
    }

    void OnDestroy()
    {
        if(SoundSystem.instance == this){
            SoundSystem.instance = null;
        }
    }
}
