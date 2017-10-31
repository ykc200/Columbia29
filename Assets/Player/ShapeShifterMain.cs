using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifterMain : MonoBehaviour {

    //Change variable
    public bool change = false;
    //Turns these stuff on and off
    public GameObject Triangle_Player;
    public GameObject Square_Player;
	public GameObject Circle_Player;
    public GameObject Bullet;
    public GameObject CircleBullet;


    // Use this for initialization
    void Start () {
        GameObject SPPT = GameObject.Find("Triangle_Player");
        GameObject SPPM = GameObject.Find("Square_Player");
		GameObject SPPC = GameObject.Find ("Circle_Player");
        SPPT.transform.position = SPPM.transform.position;
		SPPC.transform.position = SPPM.transform.position;
        CircleBullet.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject SPPT = GameObject.Find("Triangle_Player");
        GameObject SPPM = GameObject.Find("Square_Player");
		GameObject SPPC = GameObject.Find ("Circle_Player");
        //I was thinking about only using one key, but that didn't work
        if (Input.GetKeyDown(KeyCode.Q))
        {
            change = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            change = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Circle_Player.SetActive(true);
        }
        if (change == false)
        {
            Triangle_Player.SetActive(false);
            Bullet.SetActive(true);
            Square_Player.SetActive(true);
        }
        if (change == true)
        {
            Bullet.SetActive(false);
            Square_Player.SetActive(false);
            Triangle_Player.SetActive(true);
        }
    }
}
