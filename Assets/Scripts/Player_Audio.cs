using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    public AK.Wwise.Event jumpSound;
    public AK.Wwise.Event doubleJumpSound;
    public AK.Wwise.Event landSound;
    public AK.Wwise.Event bounceSound;
    public AK.Wwise.Event footstepSound;
    public AK.Wwise.Event collectFruitSound;
    public AK.Wwise.Event deathSound;


    void Start()
    {

    }

    public void playFoostep()
    {
        footstepSound.Post(gameObject);
    }

    public void playJumpSound()
    {
        jumpSound.Post(gameObject);
    }
    public void playDoubleJumpSound()
    {
        doubleJumpSound.Post(gameObject);
    }
    public void playLandSound()
    {
        landSound.Post(gameObject);
    }
    public void playBounceSound()
    {
        bounceSound.Post(gameObject);
    }
    public void playCollectFruitSound()
    {
        bounceSound.Post(gameObject);
    }
    public void playDeathSound()
    {
        deathSound.Post(gameObject);
    }
}
