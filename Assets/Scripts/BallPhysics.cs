using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField] float speed;
    [Range(1,5)] [SerializeField] float deviateFactor = 1;
    public Vector3 velo;
    private float counter;
    public bool shootable;
    private RacketController player;
    private int playerHealth;
    private BrickController brick;
    private LivesManager lM;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        shootable = true;
        player = FindObjectOfType<RacketController>();
        lM = FindObjectOfType<LivesManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = velo;
        HandleShootable();
        HandleCounter();
    }

    private void HandleCounter()
    {
        if (counter > Mathf.Epsilon)
        {
            counter--;
        }
        else if (counter <= Mathf.Epsilon)
        {
            counter = 0;
        }
    }

    void HandleShootable()
    {
        if (shootable)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y+0.5f);
            rb.velocity = Vector3.zero;
        }
        if (Input.GetButtonDown("Jump") && shootable)
        {
            velo = new Vector2(0f, speed);
            shootable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "brick" && counter == 0)
        {
            //Destroy(collision.gameObject);
            velo.y = -velo.y;
            counter = 1;
            brick = collision.gameObject.GetComponent<BrickController>(); ;
            brick.SetHitPoints(brick.GetHitPoints()-1);
        }
        if (counter == 0 && collision.gameObject.tag == "UpperWall")
        {
            velo.y = -velo.y;
            counter = 1;
        }
        else if(counter == 0 && collision.gameObject.CompareTag("Player"))
        {
            velo.y = -velo.y;
            float deviateValue;
            deviateValue = transform.position.x - collision.gameObject.transform.position.x;
            deviateValue /= collision.collider.bounds.size.x / 2f;
            deviateValue *= deviateFactor;
            velo.x += deviateValue;
            counter = 1;
        }
        if(collision.gameObject.tag == "walls" && counter == 0)
        {
            velo.x = -velo.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            lM.ballCount--;
            lM.DamagePlayer();
        }
    }
    
}
