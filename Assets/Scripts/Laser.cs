using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer _beam;
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private float _maxLength;

    [SerializeField] private ParticleSystem _muzzleParticles;
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private float _damage;
    

    private bool keyHeldDown = false;
    [SerializeField] private float _shootDuration;
    [SerializeField] private float timeBetweenShoots;

    void Awake()
    {
        _beam.enabled = false;     
    }

    void Activate()
    {
        _beam.enabled = true;      
        SoundSystem.instance.PlaySound();  
        _muzzleParticles.Play();
        //

            // Check for a hit and apply damage to the enemy if hit
        RaycastHit hit;
        Ray ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
        if (Physics.Raycast(ray, out hit, _maxLength))
        {
            Collider hitCollider = hit.collider;
            if (hitCollider.CompareTag("Target"))
            {
                _hitParticles.Play();
                if (hitCollider.TryGetComponent(out EnemyActions enemyActions))
                {
                    Vector3 _hitDirection = ray.direction;

                    enemyActions.ApplyDamage(_damage);
                    enemyActions.MoveBack(_hitDirection);
                }
            }
        }
    }

    void Deactivate()
    {
        _beam.enabled = false;       
        _beam.SetPosition(0, _muzzlePoint.position);
        _beam.SetPosition(1, _muzzlePoint.position); 
/*         _muzzleParticles.Stop();
         */
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!keyHeldDown)
            {
                keyHeldDown = true;
                StartCoroutine(RepeatFunction());
/*                 if (hit.transform.CompareTag("Target")) {
                    _hitParticles.Play(); 
                } */
            }
        }else if(Input.GetMouseButtonUp(0)){
            keyHeldDown = false;
            _muzzleParticles.Stop();
            _hitParticles.Stop();
            //_hitParticles.Stop();
        } 
    }

    private IEnumerator RepeatFunction()
    {
        while (keyHeldDown)
        {
            Activate();
            yield return new WaitForSeconds(_shootDuration);
            Deactivate();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, _maxLength);
        Vector3 hitPosition = cast ? hit.point : _muzzlePoint.position + _muzzlePoint.forward * _maxLength;

        _beam.SetPosition(0, _muzzlePoint.position);
        _beam.SetPosition(1, hitPosition);

        _hitParticles.transform.position = hitPosition;
    }

}
