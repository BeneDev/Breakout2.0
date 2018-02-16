using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    [SerializeField] int hitPoints;
    [SerializeField] GameObject[] powerUps = new GameObject[3];
    //[SerializeField] GameObject powerUp2;
    private GameObject player;
    [SerializeField] int dropChance = 50;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (hitPoints <= 0)
        {
            Die();
        }
	}

    public int GetHitPoints()
    {
        return hitPoints;
    }

    public void SetHitPoints(int value)
    {
        hitPoints = value;
    }

    void SpawnPowerup(int whichPower)
    {
        Instantiate(powerUps[whichPower], transform.position, transform.rotation);
    }

    void Die()
    {
        if (Random.Range(1f, 100f) <= dropChance)
        {
            SpawnPowerup((int)Random.Range(0, powerUps.Length));
        }
        Destroy(gameObject);
    }
}
