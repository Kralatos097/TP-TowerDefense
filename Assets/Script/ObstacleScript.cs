using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public int speed;
    public float xDest;
    public float zDest;
    public float waitTime = 2;
    public int startXDirection = 1;
    public int startZDirection = 1;

    private ObstacleState currentState = ObstacleState.Wait;
    private bool finishWait = false;

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ObstacleState.Wait :
                Invoke("stopWaiting", waitTime);
                if(finishWait)
                {
                    CancelInvoke();
                    if(xDest >= 0) startXDirection *= -1;
                    if(zDest >= 0) startZDirection *= -1;
                    currentState = ObstacleState.Mouving;
                    finishWait = false;
                }
                break;
            
            case ObstacleState.Mouving :
                Move();
                if(transform.position.x * startXDirection >= xDest && transform.position.z * startZDirection >= zDest)
                {
                    currentState = ObstacleState.Wait;
                }
                break;
        }
    }

    private void stopWaiting()
    {
        finishWait = true;
    }

    private void Move()
    {
        if (xDest >= 0)
        {
            transform.Translate(Vector3.right * startXDirection * speed * Time.deltaTime);
        }
        if (zDest >= 0)
        {
            transform.Translate(Vector3.forward * startZDirection * speed * Time.deltaTime);
        }
    }
}

enum ObstacleState
{
    Mouving,
    Wait,
}