using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour {

    [SerializeField] float speed;
    //private Rigidbody2D rb;
    [SerializeField] int health;
    private Vector3 mousePos;
    private BallPower bP;

	void Start () {
        //rb = GetComponent<Rigidbody2D>();
        bP = FindObjectOfType<BallPower>();
	}

    private void Update()
    {

    }

    void FixedUpdate () {
        MouseControls();
	}

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    private void Controls()
    {
        //rb.velocity = Vector3.right * speed * Input.GetAxis("Horizontal");
    }

    private void MouseControls()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BallPower")
        {
            bP.Trigger(gameObject);
        }
        else if(collision.tag == "Powerup")
        {
            collision.GetComponent
        }
    }
    */
}
