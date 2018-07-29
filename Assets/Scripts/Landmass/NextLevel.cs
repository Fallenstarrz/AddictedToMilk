using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    public int levelNumberToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When player enters trigger box load level: Switch on int passed in through inspector
        if (other.gameObject == GameManager.instance.player.gameObject)
        {
            switch (levelNumberToLoad)
            {
                case (1):
                {
                    sceneSwitcher.LoadLevel1();
                    break;
                }
                case (2):
                {
                    sceneSwitcher.LoadLevel2();
                    break;
                }
                case (3):
                {
                    sceneSwitcher.LoadLevel3();
                    break;
                }
                case (99):
                {
                    sceneSwitcher.LoadVictory();
                    break;
                }

            }
        }
    }
}
