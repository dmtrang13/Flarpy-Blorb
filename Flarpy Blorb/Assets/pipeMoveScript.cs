using UnityEngine;

public class pipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 2;
    public float deadZone = -45;
    public logicScript logic;
    private int lastMilestone = 0;
    private Animator animator;
    private bool shouldSlam;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        animator = GetComponent<Animator>();
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
        if (logic.playerScore >= 30)
        {
            shouldSlam = Random.value < 0.5f;
            if (shouldSlam && animator != null)
            {
                animator.SetTrigger("Slam");
            }
        }        
    }
}
