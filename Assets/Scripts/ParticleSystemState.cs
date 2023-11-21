using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemState : MonoBehaviour
{

    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Update is called once per frame
        if (!particleSystem.IsAlive())
        {
            // Destroy the GameObject this script is attached to
            Destroy(gameObject);
        }
    }
}
