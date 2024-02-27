using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float CameraOffset = -10f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, CameraOffset);
    }

    public void camera_KillBox()
    {
        transform.position = transform.position;
    }
}
