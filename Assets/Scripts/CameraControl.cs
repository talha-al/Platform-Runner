using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Vector3 distance;
    [SerializeField] float smoothingRate;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        distance = this.transform.position - gameManager.player.transform.position;
    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, gameManager.player.transform.position + distance, smoothingRate);
    }

}
