using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    //Check if fires
    public bool fire = false;

    //Turns on Square Bullet
    public GameObject Square_Bullet;
    

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //When space is clicked, fires
        if (Input.GetKey(KeyCode.Space))
        {
            Square_Bullet.SetActive(true);
            fire = true;
        }
	}
}
