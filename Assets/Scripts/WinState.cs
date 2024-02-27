using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    [SerializeField] private Transform pfWinStateEffect;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject resumeButton;
    public AK.Wwise.Event WinSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mainMenu.SetActive(true);
            resumeButton.SetActive(false);            
            Instantiate(pfWinStateEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            winMenu.SetActive(true);
            WinSound.Post(gameObject);
            Invoke("NextLevel", 3.0f);

        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
