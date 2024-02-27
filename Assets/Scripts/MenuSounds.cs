using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

    public AK.Wwise.Event HoverSound;
    public AK.Wwise.Event ClickSound;

    public void playHoverSound()
    {
        HoverSound.Post(gameObject);
    }

    public void playClickSound()
    {
        HoverSound.Post(gameObject);
    }
}
