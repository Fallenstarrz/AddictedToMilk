using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // If the collider is player then run function playerDead from controller_player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameManager.instance.player.gameObject)
        {
            GameManager.instance.player.playerDead();
        }
    }
}
