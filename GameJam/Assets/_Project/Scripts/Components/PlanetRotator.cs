using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public float rotationSpeed = 1;

    private void Update()
    {
        Vector3 rotation = new Vector3(0, 0, Input.GetAxis("Horizontal") * rotationSpeed);
        transform.Rotate(rotation);
    }
}
