using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreToAdd;
    public AudioClip pickUp;
    public GameObject popupText;

    // when player enters trigger add points to gameManager and play sound
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.instance.player.gameObject)
        {
            GameManager.instance.score += scoreToAdd;
            AudioSource.PlayClipAtPoint(pickUp, transform.position, 2);
            Instantiate(popupText, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    // Make GUI pop up in world space at the location of the pickup
}
