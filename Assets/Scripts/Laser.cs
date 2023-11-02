using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer _beam;
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private float _maxLength;

    private bool keyHeldDown = false;
    private float repeatRate = 0.05f;
    private float timeBetweenShoots = 0.05f;

    void Awake()
    {
        _beam.enabled = false;        
    }

    void Activate()
    {
        _beam.enabled = true;        
    }

    void Deactivate()
    {
        _beam.enabled = false;       
        _beam.SetPosition(0, _muzzlePoint.position);
        _beam.SetPosition(1, _muzzlePoint.position); 
    }

    void Update()
    {
/*         if(Input.GetMouseButtonDown(0)) {
            Activate();
            Invoke("Deactivate", timeBetweenShoots);
        } */
        //else if(Input.GetMouseButtonUp(0)) Deactivate();

        if (Input.GetMouseButtonDown(0))
        {
            if (!keyHeldDown)
            {
                keyHeldDown = true;
                StartCoroutine(RepeatFunction());
            }
        }else if(Input.GetMouseButtonUp(0)) keyHeldDown = false;
/*         else
        {
            keyHeldDown = false;
            Debug.Log("Held down false");
        } */
    }

    private IEnumerator RepeatFunction()
    {
        while (keyHeldDown)
        {
            // Call your function here
            Debug.Log("Repeated");
            Activate();
            yield return new WaitForSeconds(repeatRate);
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
    }

}
