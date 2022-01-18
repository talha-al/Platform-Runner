using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingWall : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] Transform target;
    [SerializeField] Slider progressSlider;
    GameManager gameManager;
    public Transform baseDot;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        progressSlider.enabled = true;
        progressSlider.gameObject.SetActive(true);
    }

    void Update()
    {
        MoveTheCamera();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PaintTheWall();
        }
    }

    private void MoveTheCamera()
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, target.transform.position, moveSpeed);
    }

    private void PaintTheWall()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Paint")
            {
                hit.collider.enabled = false;
                progressSlider.value += 1;
                if (progressSlider.value >= 35)
                {
                    gameManager.OpenFinishPanel();
                }
            }

            if (hit.collider.tag == "Wall")
            {
                Instantiate(baseDot, new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.01f), Quaternion.identity);

            }
        }
    }
}
