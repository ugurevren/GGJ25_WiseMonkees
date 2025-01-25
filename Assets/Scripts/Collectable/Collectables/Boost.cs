using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private enum State { Idle, Caught }
    private State state = State.Idle;

    private Vector2 catchSpeed;
    private GameObject caughtPlayer;

    public void Caught(GameObject playerGo)
    {
        state = State.Caught;
        caughtPlayer = playerGo;
        catchSpeed = caughtPlayer.GetComponent<Rigidbody2D>().velocity;
        caughtPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Booster caught!");
    }

    private void FixedUpdate()
    {
        if (state == State.Caught && caughtPlayer != null)
        {
            caughtPlayer.transform.position = transform.position;
        }
    }

    private void Release()
    {
        if (caughtPlayer != null)
        {
            //var rb = caughtPlayer.GetComponent<Rigidbody2D>();
            //rb.velocity = new Vector2(catchSpeed.x, 400);
            caughtPlayer = null;
            state = State.Idle;
            Debug.Log("Player released!");
        }
    }

}
