using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private float horizontal;
    public float horizontalMovementSpeed;
    public float verticalMovementSpeed;
    [SerializeField] float accelerationValue = 3f;
    Rigidbody rigidBody;
    GameManager gameManager;
    Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {
        if (gameManager.startGame && !gameManager.gameOverControl)
        {
            CharacterMove();
        }
    }

    private void CharacterMove()
    {
        animator.enabled = true;
        transform.Translate(Vector3.forward * verticalMovementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.left * horizontalMovementSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, -30, 12.5f), 70 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.right * horizontalMovementSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 30, 12.5f), 70 * Time.deltaTime);
        }
        else
        {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 0, 0), 40 * Time.deltaTime);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            animator.enabled = false;
            gameManager.GameOver();
        }

        if (other.gameObject.tag == "AccelerationPlatform")
        {
            rigidBody.AddForce(0, 0, accelerationValue, ForceMode.Impulse);
        }

        if (other.gameObject.tag == "Finish")
        {
            animator.enabled = false;
            gameManager.GoToPaintWall();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "RotatePlatform")
        {
            rigidBody.velocity = new Vector3(-1f, 0, 0);
        }
    }

}
