using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Bullet : MonoBehaviour {
    public float speedcb = 25f;
    float localAngleCB;
    Vector3 mobBulletPos;
    Vector3 mobPosCB;
    float timeCounterCB;
    bool localBool = false;
    int counterCB;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject CirclePlayer = GameObject.Find("Circle_Player");
        ReflectController rc = CirclePlayer.GetComponent<ReflectController>();
        GameObject Mob_Bullet = GameObject.Find("Mob_Bullet");
        MobBullet mbb = Mob_Bullet.GetComponent<MobBullet>();
        PlayerToMob();
        localBool = rc.reflectRC;
        if (localBool && timeCounterCB < 1.3f)
        {
            if (counterCB < 1)
            {
                //Get the bullet to player and mouse angle
                transform.position = mbb.b4dissPos; //mbb.transform.position;  
                counterCB++;
            }
            //Set the direction and fires
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, localAngleCB) * Vector2.right);
            transform.Translate(dir * speedcb * Time.deltaTime);
            rc.singleReflect = false;
            timeCounterCB = timeCounterCB + Time.deltaTime;

        }
        //After sometime, the bullet will disapear and ready to be fired again
        else if (localBool && timeCounterCB >= 1.3f)
        {
            counterCB = 0;
            timeCounterCB = 0f;
            rc.reflectRC = false;
            gameObject.SetActive(false);
        }else if (!localBool)
        {
            counterCB = 0;
            timeCounterCB = 0f;
            rc.reflectRC = false;
            gameObject.SetActive(false);
        }
    }

    void PlayerToMob()
    {
        GameObject TestMob = GameObject.Find("Test_Mob");
        GameObject CirclePlayer = GameObject.Find("Circle_Player");
        ReflectController rc = CirclePlayer.GetComponent<ReflectController>();
        mobPosCB = TestMob.transform.position;
        mobBulletPos = rc.MBPos;
        Vector3 mouse_pos = new Vector3(0f, 0f, 0f);
        Vector3 object_pos = new Vector3(0f, 0f, 0f);
        mouse_pos = mobPosCB;// + new Vector3(2.9f, 0f, 0f);//Offset
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos =  mobBulletPos;
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        localAngleCB = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //Credit : (Dusk answers.unity3d.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html)
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            transform.position = new Vector3(999f, 999f, 999f);
            timeCounterCB = 1.4f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            transform.position = new Vector3(999f, 999f, 999f);
            timeCounterCB = 1.4f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            transform.position = new Vector3(999f, 999f, 999f);
            timeCounterCB = 1.4f;
        }
    }
    
}
