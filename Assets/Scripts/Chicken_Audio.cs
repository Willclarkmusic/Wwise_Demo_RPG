using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Audio : MonoBehaviour
{
    public AK.Wwise.Event chickenFootstep;

    public void playChickenFoostep()
    {
        chickenFootstep.Post(gameObject);
    }

}
