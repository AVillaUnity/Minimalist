using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

    [SerializeField] float m_rotationsPerMinute = 1.0f;
    Rotate rotator = null;

    private void Start()
    {
        rotator = GameObject.FindObjectOfType<Rotate>();
        rotator.rotateEvent += OnRotate;
    }

    void OnRotate(float value)
    {
        float degrees = Time.deltaTime / 60 * m_rotationsPerMinute * 360;
        transform.RotateAround(transform.position, Vector3.back * Input.GetAxis("Horizontal"), degrees);
    }

}
