using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Trigger()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You're better now");
        Trigger();
    }
}
