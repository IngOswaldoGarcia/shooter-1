using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDirection : MonoBehaviour
{
    int layerMask;// The layer to ignore

    void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("IgnoreRaycast"); 
        layerMask = ~layerMask; // Invert the mask to ignore the specified layer
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición del cursor en la pantalla
        Vector3 cursorScreenPosition = Input.mousePosition;

        // Convertir la posición del cursor de la pantalla a un rayo en el mundo
        Ray ray = Camera.main.ScreenPointToRay(cursorScreenPosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
        {
            // Obtener la posición del cursor en el mundo en el mismo plano que el objeto
            Vector3 cursorWorldPosition = hit.point;
            cursorWorldPosition.y = transform.position.y; // Mantener la misma altura que el objeto

            // Calcular la dirección hacia la posición del cursor
            Vector3 direction = cursorWorldPosition - transform.position;

            // Rotar el objeto horizontalmente hacia la dirección del cursor
            transform.forward = new Vector3(direction.x, 0f, direction.z);
        }
    }
}
