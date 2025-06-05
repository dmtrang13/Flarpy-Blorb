using UnityEngine;

public class cloudMoveScript : MonoBehaviour
{
    public float moveSpeed = 4;
    public float deadZone = -100;
    public logicScript logic;
    private int lastMilestone = 0;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

        if (logic.playerScore >= lastMilestone + 10)
        {
            moveSpeed += 2f;
            lastMilestone = logic.playerScore;
        }      
    }
}
