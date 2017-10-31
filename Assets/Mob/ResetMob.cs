using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMob : MonoBehaviour {
    
    //Mobs to reset
    //Could save some work if i knew how to use prefabs batter
    public GameObject Test_Mob;
    public GameObject Test_Mob1;
    public GameObject Test_Mob2;
    public GameObject Test_Mob3;
    public GameObject Test_Mob4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Resets Mobs
        if (Input.GetKey(KeyCode.Z))
        {
            Test_Mob.SetActive(true);
            Test_Mob1.SetActive(true);
            Test_Mob2.SetActive(true);
            Test_Mob3.SetActive(true);
            Test_Mob4.SetActive(true);
        }
        
    }
}
