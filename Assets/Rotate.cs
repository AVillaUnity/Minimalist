using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rotate : MonoBehaviour {

    public delegate void OnKeyPress(float value);
    public event OnKeyPress rotateEvent;


	// Update is called once per frame
	void Update () {


        if (Input.GetButton("Horizontal"))
        {
            rotateEvent(Input.GetAxis("Horizontal"));
        }
        
	}
}
