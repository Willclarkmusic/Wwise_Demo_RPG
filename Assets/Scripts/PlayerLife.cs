using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetTrigger("Death");
        AkSoundEngine.SetState("PlayerLife", "Dead");
        Invoke("GameReset", 1.0f);
    }

    private void GameReset()
    {
        AkSoundEngine.StopAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
