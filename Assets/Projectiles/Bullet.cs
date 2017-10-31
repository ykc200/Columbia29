using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour {
    //Speed of Bullet
    [Range(1f, 100f)]
    public float speedb = 1f;

    //Time Counter
    [Range(0f, 10f)]
    public float timeCounter1 = 0f;
    
    //Bool for fire status
    public bool firee = false;

    //Local Angle for bullet
    float localAngle = 0f;

    //int to make things exec only once
    int counter = 0;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject Projectile = GameObject.Find("Projectiles");
        Fire fireee = Projectile.GetComponent<Fire>();
        GameObject FlMs = GameObject.Find("Square_Player");
        FollowMouseSqr fl = FlMs.GetComponent<FollowMouseSqr>();
        
        //Check fire status
        firee = fireee.fire;
        
        if (firee&&timeCounter1<1.2f)
        {
            
            if (counter < 1)
            {
                //Get the bullet to player and mouse angle
                transform.position = FlMs.transform.position;
                localAngle = fl.angle;
                counter++;
            }
            //Set the direction and fires
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, localAngle) * Vector2.right);
            transform.Translate(dir * speedb * Time.deltaTime);
            timeCounter1 = timeCounter1 + Time.deltaTime;
        
        }
        //After sometime, the bullet will disapear and ready to be fired again
        else if (firee && timeCounter1 >= 1.2f)
        {
            counter = 0;
            timeCounter1 = 0f;
            fireee.fire = false;
            transform.position = FlMs.transform.position;
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            timeCounter1 = 1.4f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            timeCounter1 = 1.4f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            timeCounter1 = 1.4f;
        }
    }
}
