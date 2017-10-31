using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBullet : MonoBehaviour {

    //Vector3 for playerPos
    public Vector3 playerPos = new Vector3(0f,0f,0f);

    //Local angle
    public float anglemb;

    //Speed of Bullet
    [Range(0f, 100f)]
    public float speedmb;

    //Time Counter
    float timeCountermb;

    //Counter
    int countermb;

    //Vector3 for mobPos
    public Vector3 mobPos = new Vector3(0f, 0f, 0f);

    public bool getBack = false;

    public Vector3 b4dissPos = new Vector3(0f, 0f, 0f);

    bool hit = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject PlayerMB = GameObject.Find("Player");
        playerPos = PlayerMB.transform.position;
        GameObject Mob = GameObject.Find("Test_Mob");
        mobPos = Mob.transform.position;
        if (timeCountermb < 1.2f)
        {
            if (countermb < 1)
            {
                //Get the mob to player angle
                transform.position = mobPos;
                MobbToPlayer();
                countermb++;
            }
            //Set the direction and fires
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, anglemb) * Vector2.right);
            transform.Translate(dir * speedmb * Time.deltaTime);
            timeCountermb = timeCountermb + Time.deltaTime;
        }
        //After sometime, the bullet will disapear and ready to be fired again
        else if (timeCountermb >= 1.2f)
        {
            countermb = 0;
            timeCountermb = 0f;
        }
        else if (getBack)
        {
            countermb = 0;
            timeCountermb = 0f;
            getBack = false;
        }
        if (hit)
        {
            transform.position = new Vector3(999f, 999f, 999f);
            hit = false;
        }

        

    }
    void MobbToPlayer()
    {
        Vector3 mouse_pos = new Vector3(0f, 0f, 0f);
        Vector3 object_pos = new Vector3(0f, 0f, 0f);
        mouse_pos = playerPos + new Vector3(2.9f,0f,0f);//Offset
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = mobPos;
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        anglemb = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //Credit : (Dusk answers.unity3d.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html)
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Circle"))
        {
            timeCountermb = 1.4f;
            getBack = true;
            b4dissPos = transform.position;
            hit = true;
            //GameObject Mob = GameObject.Find("Test_Mob");
            //b4dissPos = transform.position;
            //ransform.position = new Vector3(999f, 999f, 999f);//Mob.transform.position;
            //timeCountermb = 1.4f;
            //getBack = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Circle"))
        {
            //GameObject Mob = GameObject.Find("Test_Mob");
            timeCountermb = 1.4f;
            getBack = true;
            hit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Circle"))
        {
            timeCountermb = 1.4f;
            getBack = true;
        }
    }
    
}
