using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerPower : PowerUp {

    private RacketController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<RacketController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Trigger()
    {
        player.transform.localScale = new Vector2(2f, 1f);
    }
}
