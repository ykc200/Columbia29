using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseTri : MonoBehaviour {
    public float angleTri;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition();
    }

    //Basic Mouse tracking
    //Mouse to Angle in respect of player Positions
    void mousePosition()
    {
        Vector3 mouse_pos = new Vector3(0f, 0f, 0f);
        Vector3 object_pos = new Vector3(0f, 0f, 0f);
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angleTri = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, (angleTri + 30));//Offset for triangle
        //Credit : (Dusk answers.unity3d.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html)
    }
}
