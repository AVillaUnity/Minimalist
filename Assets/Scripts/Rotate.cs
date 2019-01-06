using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [SerializeField] bool autoRotate = false;

    private bool turningLeft = false;
    private bool turningRight = false;

	public delegate void OnKeyPress(float value);
	public event OnKeyPress rotateEvent;


	// Update is called once per frame
	void Update () {

        if (autoRotate)
            rotateEvent(1.0f);
        else
        {
#if UNITY_STANDALONE
            if (Input.GetButton("Horizontal"))
                rotateEvent(-Input.GetAxis("Horizontal"));
#endif
            if (turningLeft)
                rotateEvent(1.0f);
            else if (turningRight)
                rotateEvent(-1.0f);
        }

		

    }

    public void LeftButtonPressed()
    {
        turningRight = false;
        turningLeft = true;
    }

    public void LeftButtonReleased()
    {
        turningLeft = false;
    }


    public void RightButtonPressed()
    {
        turningLeft = false;
        turningRight = true;
    }

    public void RightButtonReleased()
    {
        turningRight = false;
    }
}
