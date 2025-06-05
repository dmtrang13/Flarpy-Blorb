using System.Runtime.InteropServices;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float flapStrength;
    public logicScript logic;
    public bool birdIsAlive = true;
    public float outOfBoundsTimer = 0f;
    public float timeToDie = 5f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        birdRigidBody.simulated = false;
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        if (birdIsAlive)
        {
            Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
            if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
            {
                outOfBoundsTimer += Time.deltaTime;
                if (outOfBoundsTimer >= timeToDie)
                {
                    logic.gameOver();
                    birdIsAlive = false;
                }
            }
            else
            {
                outOfBoundsTimer = 0f;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
