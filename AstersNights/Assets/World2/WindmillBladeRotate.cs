using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillBladeRotate : MonoBehaviour
{
    public float rotationSpeed = 15f;
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
