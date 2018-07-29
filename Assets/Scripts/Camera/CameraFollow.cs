using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        if (GameManager.instance.player != null)
        {
            player = GameManager.instance.player.gameObject.transform;
            offset = transform.position - player.position;
        }
	}

    // Called after each frame, but before next one begins
    void LateUpdate ()
    {
        // Set character if there isn't one
        if (player == null)
        {
            if (GameManager.instance.player != null)
            {
                player = GameManager.instance.player.gameObject.transform;
            }
        }
        // Make camera follow player
        if (player != null)
        {
            transform.position = player.position + offset;
        }
	}
}
