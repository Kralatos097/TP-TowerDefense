using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public int speed;
    public float xDest;
    public float waitTime = 2;

    private ObstacleState currentState = ObstacleState.Wait;
    private int direction = 1;
    private bool finishWait = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ObstacleState.Wait :
                Invoke("stopWaiting", waitTime);
                if (finishWait)
                {
                    direction *= -1;
                    currentState = ObstacleState.Mouving;
                    finishWait = false;
                    CancelInvoke();
                }
                break;
            
            case ObstacleState.Mouving :
                Move();
                if (transform.position.x * direction >= xDest) currentState = ObstacleState.Wait;
                break;
        }
    }

    private void stopWaiting()
    {
        finishWait = true;
    }

    private void Move()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
}

enum ObstacleState
{
    Mouving,
    Wait,
}