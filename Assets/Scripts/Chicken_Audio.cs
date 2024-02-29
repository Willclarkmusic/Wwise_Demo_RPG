using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Audio : MonoBehaviour
{
    public AK.Wwise.Event chickenFootstep;
    public AK.Wwise.Event ChickenGetHit;
    public AK.Wwise.Event ChickenDeath;



    public void playChickenFoostep()
    {
        chickenFootstep.Post(gameObject);
    }
    public void playChickenGetHit()
    {
        ChickenGetHit.Post(gameObject);
    }

    public void playChickenDeath()
    {
        ChickenDeath.Post(gameObject);
    }
}
