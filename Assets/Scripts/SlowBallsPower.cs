using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBallsPower : PowerUp {

    public GameObject[] balls;
    [SerializeField] float slowDownMultiplier = 0.8f;

	// Use this for initialization
	void Start () {
        balls = GameObject.FindGameObjectsWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Trigger()
    {
        for(int i = 0; i<balls.Length;i++)
        {
            balls[i].GetComponent<BallPhysics>().velo *= slowDownMultiplier;
        }
    }
}
