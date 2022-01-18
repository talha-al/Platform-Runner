using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatickObstacles : MonoBehaviour
{
    public Color color;
    MeshRenderer _meshRend;
    void Start()
    {
        _meshRend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _meshRend.material.color = color;

    }
}
