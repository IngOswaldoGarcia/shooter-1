using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreation : MonoBehaviour
{
    public int numberOfQuadsX = 5; // Adjust the number of quads in the X direction.
    public int numberOfQuadsZ = 5; // Adjust the number of quads in the Z direction.
    public float quadSize = 1.0f; // Adjust the size of each quad.

    public GameObject floor;

    void Start()
    {
        floor.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
        floor.transform.localRotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));

        for (float x = -50f; x <= 50f; x+=10f)
        {
            for (float z = -50f; z <= 50f; z+=10f)
            {
                GameObject instantiatedObject = Instantiate(floor, new Vector3(x, 0.0f, z), floor.transform.rotation);
                // Optionally, you can also set the parent of the instantiated object.
                instantiatedObject.transform.parent = transform; // Set the parent to this GameObject.
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
