using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : BaseCollectable
{
    private enum States { IDLE, CAUGHT }
    private States state = States.IDLE;
    private Vector2 catchSpeed;
    private GameObject caughtCat;

    public Animator AnimatedSprite;
    public AudioSource BoostAudio;

    public void Caught(GameObject cat)
    {
        state = States.CAUGHT;
        var catMotion = cat.GetComponent<CatMotion>();
        catchSpeed = catMotion.Motion;
        caughtCat = cat;
        catMotion.Motion = Vector2.zero;

        AnimatedSprite.Play("charge");
        BoostAudio.Play();

        Invoke(nameof(ReleaseCat), 3f); // 3 saniye sonra bırak
    }

    private void ReleaseCat()
    {
        state = States.IDLE;
        var catMotion = caughtCat.GetComponent<CatMotion>();
        Vector2 newMotion = catchSpeed.normalized;
        newMotion.y = -1;
        newMotion *= 400;
        catMotion.Motion = newMotion;
        caughtCat = null;
        AnimatedSprite.Play("idle");
    }

    private void Update()
    {
        if (state == States.CAUGHT && caughtCat != null)
        {
            caughtCat.transform.position = transform.position;
        }
    }
}
