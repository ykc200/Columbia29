using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //HitReg for mobs - If touches bullets or triangle
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") || other.CompareTag("Triangle") || other.CompareTag("CircleProjectile"))
        {
            gameObject.SetActive(false);
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") || other.CompareTag("Triangle") || other.CompareTag("CircleProjectile"))
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") || other.CompareTag("Triangle") || other.CompareTag("CircleProjectile"))
        {
            gameObject.SetActive(false);
        }
    }
}
