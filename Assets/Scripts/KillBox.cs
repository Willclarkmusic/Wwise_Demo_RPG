using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] object Camera;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameReset", 1.0f);
        }
    }

    public void GameReset()
    {
        AkSoundEngine.StopAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
