using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyWorm : BaseCollectable
{
    private enum States { IDLE, MAGNETIZED, PICKED_UP }
    private States state = States.IDLE;
    private Transform magnetizedTo;

    public AudioSource Audio;
    public SpriteRenderer Sprite;

    protected override void OnPickup()
    {
        state = States.PICKED_UP;
    }

    public void SetSound(AudioClip sound)
    {
        Audio.clip = sound;
    }

    public void SetTexture(Sprite texture)
    {
        Sprite.sprite = texture;
    }

    private void Update()
    {
        if (state == States.MAGNETIZED && magnetizedTo != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, magnetizedTo.position, 100f * Time.deltaTime);
        }
    }

    public void Magnetized(Transform to)
    {
        if (state != States.PICKED_UP)
        {
            magnetizedTo = to;
            state = States.MAGNETIZED;
        }
    }

    public void Demagnetized()
    {
        state = States.IDLE;
    }
   
}
