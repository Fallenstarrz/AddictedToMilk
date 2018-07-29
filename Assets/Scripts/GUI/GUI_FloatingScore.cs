using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_FloatingScore : MonoBehaviour
{
    public float destroyAfter;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, destroyAfter);
	}
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
