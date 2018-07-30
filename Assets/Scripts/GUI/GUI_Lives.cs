using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Lives : MonoBehaviour
{
    public Image life1;
    public Image life2;
    public Image life3;
	
	// Update is called once per frame
	void Update ()
    {
		switch (GameManager.instance.playerLives)
        {
            case (0):
            {
                life3.enabled = false;
                life2.enabled = false;
                life1.enabled = false;
                break;
            }
            case (1):
            {
                life3.enabled = false;
                life2.enabled = false;
                break;
            }
            case (2):
            {
                life3.enabled = false;
                break;
            }
        }
	}
    public void resetLives()
    {
        life1.enabled = true;
        life2.enabled = true;
        life3.enabled = true;
    }
}
