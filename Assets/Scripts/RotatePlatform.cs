using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.1f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90), rotationSpeed);
    }
}
