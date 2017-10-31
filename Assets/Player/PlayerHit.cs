using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {
    
    //Turns these on and off
    public GameObject Player;
    public GameObject PlayerBullet;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Player HitReg - If touches mobs or mob bullets
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mob") || other.CompareTag("MobProjectile"))
        {
            Player.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Mob") || other.CompareTag("MobProjectile"))
        {
            Player.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mob") || other.CompareTag("MobProjectile"))
        {
            Player.gameObject.SetActive(false);
        }
    }
}
