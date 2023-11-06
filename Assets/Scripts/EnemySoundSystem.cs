using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundSystem : MonoBehaviour
{
    public static EnemySoundSystem instance;
    public AudioClip[] audioExplosion = new AudioClip[3];
    public AudioSource audioSource;
    // Start is called before the first frame updat

    void Awake()
    {
        if(EnemySoundSystem.instance == null){
            EnemySoundSystem.instance = this;
        }else if (EnemySoundSystem.instance != this){
            Destroy(gameObject);
        }
    }
    public void ExplosionSound(){
        int randomSound = Random.Range(0, 3);
        audioSource.PlayOneShot(audioExplosion[randomSound], 2F);
    }

    void OnDestroy()
    {
        if(EnemySoundSystem.instance == this){
            EnemySoundSystem.instance = null;
        }
    }
}
