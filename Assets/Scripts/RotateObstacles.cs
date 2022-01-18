using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RotateObstacles : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.2f, moveSpeed = 1.5f;
    [SerializeField] private float _minX = -0.8f, _maxX = -0.8f;
    Rigidbody _rb;
    private bool obstacleControl = true;
    public bool moveTheObject = true;
    public bool RotateTheObject = true;
    public bool changeRotation = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (moveTheObject) MoveOfObstacles();
        else _rb.velocity = Vector3.zero;

        if (RotateTheObject) RotateOfObstacles();


    }

    private void RotateOfObstacles()
    {
        transform.Rotate(new Vector3(0, changeRotation ? 90 : -90, 0), rotationSpeed);
    }

    private void MoveOfObstacles()
    {
        if (transform.position.x <= _minX)
        {
            _rb.velocity = new Vector3(moveSpeed, 0, 0);
            obstacleControl = true;
        }
        else if (transform.position.x >= _maxX || (transform.position.x >= _minX && !obstacleControl))
        {
            _rb.velocity = new Vector3(-moveSpeed, 0, 0);
            obstacleControl = false;
        }
        else if (transform.position.x <= _maxX && obstacleControl)
        {
            _rb.velocity = new Vector3(moveSpeed, 0, 0);
        }
    }

}
