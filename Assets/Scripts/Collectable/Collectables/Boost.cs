using System.Collections;
using UnityEngine;

public class Boost : BaseCollectable
{
    private enum State { Idle, Caught }
    private State state = State.Idle;

    public float boosterLevel = 1f;
    private Vector2 catchSpeed;
    private GameObject caughtPlayer;

    private void Start()
    {
        type = Type.BOOSTER;
    }

    protected override void OnPickup(GameObject go)
    {
        Caught(go);
    }

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
            StartCoroutine(ReleaseAfterSeconds(2));
        }
    }

    private IEnumerator ReleaseAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Release();
    }

    private void Release()
    {
        if (caughtPlayer != null)
        {
            var rb = caughtPlayer.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.up * (10f+(boosterLevel*5f));
            caughtPlayer = null;
            state = State.Idle;
            Debug.Log("Player released!");
        }
    }

}
