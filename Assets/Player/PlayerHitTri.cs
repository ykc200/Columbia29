using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitTri : MonoBehaviour {

    //Turns player on and off
    public GameObject PlayerTriHit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MobProjectile"))
        {
            PlayerTriHit.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MobProjectile"))
        {
            PlayerTriHit.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MobProjectile"))
        {
            PlayerTriHit.gameObject.SetActive(false);
        }
    }
}
