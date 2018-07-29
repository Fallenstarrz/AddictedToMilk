using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Score : MonoBehaviour
{
    public Text scoreNum;
	
	// Update is called once per frame
	void Update ()
    {
        scoreNum.text = GameManager.instance.score.ToString();
	}
}
