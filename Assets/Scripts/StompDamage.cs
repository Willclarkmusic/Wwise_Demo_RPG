using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompDamage : MonoBehaviour
{

    public int damageAmount = 1;
    public GameObject player;
    private Rigidbody2D rb;
    public float bounce = 5f;
    public GameObject chicken;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }



}
