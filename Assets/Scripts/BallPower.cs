using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPower : PowerUp {

    [SerializeField] GameObject ballPrefab;
    private LivesManager lM;
    private GameObject player;

	// Use this for initialization
	void Start () {
        lM = FindObjectOfType<LivesManager>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Trigger()
    {
        if (lM.ballCount <= 1)
        {
            GameObject ball = Instantiate(ballPrefab, player.transform.position, Quaternion.identity);
            lM.ballCount++;
        }
    }

}
