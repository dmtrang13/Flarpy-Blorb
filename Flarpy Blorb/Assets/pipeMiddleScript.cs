using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    public logicScript logic;
    private bool hasScored = false;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasScored && collision.gameObject.layer == 3)
        {
            logic.updateScore(1);
            hasScored = true;
        }
    }
}

