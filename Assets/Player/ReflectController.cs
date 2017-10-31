using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectController : MonoBehaviour {
    public bool reflectRC = false;
    public float counterRC = 0f;
    public float counterRC2 = 0f;
    [Range (0f,3f)]
    public float reflex = 0f;
    public Vector3 MBPos = new Vector3(0f, 0f, 0f);
    public GameObject CircleBullet;
    public bool singleReflect = true;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(counterRC<5f && singleReflect)
        {
            CircleBullet. SetActive(true);
            counterRC = counterRC + Time.deltaTime;
        }
        else if(counterRC>5f && singleReflect)
        {
            counterRC = 0f;
            reflectRC = false;
            CircleBullet.SetActive(false);
            gameObject.SetActive(false);
        }
        if (!singleReflect)
        {
            counterRC2 = counterRC2 + Time.deltaTime;
            if (counterRC2 >= 3f)
            {
                singleReflect = true;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MobProjectile"))
        {
            reflectRC = true;
            GameObject MobBullet = GameObject.Find("Mob_Bullet");
            MBPos = MobBullet.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MobProjectile"))
        {
            reflectRC = true;
            GameObject MobBullet = GameObject.Find("Mob_Bullet");
            MobBullet mb = MobBullet.GetComponent < MobBullet>();
            MBPos = MobBullet.transform.position;
            mb.getBack = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MobProjectile"))
        {
            reflectRC = true;
            GameObject MobBullet = GameObject.Find("Mob_Bullet");
            MobBullet mb = MobBullet.GetComponent<MobBullet>();
            MBPos = MobBullet.transform.position;
            mb.getBack = true;
        }
    }
}
