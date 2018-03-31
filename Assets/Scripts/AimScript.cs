﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimScript : MonoBehaviour {

    public bool aimingEnabled = false;
    public Transform target;
    public GameObject aimSlider;
    public GameObject ball;
    Camera cam;

    float aimAngle = 0.0f;
    [SerializeField] float BallSpeed = 1000.0f;
    Vector3 firstPressPosition;
    Vector3 holdPressPosition;
    float holdPressDistance = 0.0f;
    Rigidbody ballRigidbody;

    // Use this for initialization
    void Start () {
        ballRigidbody = ball.GetComponent<Rigidbody>();
        aimSlider.GetComponent<Slider>().value = 0;
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Velocity: " + ballRigidbody.velocity);
        if (aimingEnabled)
        {
            Vector3 screenPosition = cam.WorldToScreenPoint(target.position);
            if (AngleBetweenVectors(screenPosition, Input.mousePosition) - 90 > 70.0f)
            {
                aimAngle = 70.0f;   
            }
            else if (AngleBetweenVectors(screenPosition, Input.mousePosition) - 90 < -70.0f)
            {
                aimAngle = -70.0f;
            }
            else
            {
                aimAngle = AngleBetweenVectors(screenPosition, Input.mousePosition) - 90;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                firstPressPosition = Input.mousePosition;
                Debug.Log("Angle : " + aimAngle);

            }
            else if (Input.GetButton("Fire1"))
            {
                Debug.Log("Angle : " + aimAngle);
                viewAimSlider();
                Debug.Log("Distance: " + holdPressDistance);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                Debug.Log("Mouse up!");
                //ballRigidbody.velocity = ballRigidbody.velocity.normalized * BallSpeed;
                ballRigidbody.AddRelativeForce(Vector3.up * BallSpeed * Time.deltaTime);
                aimingEnabled = false;
                firstPressPosition = new Vector3(0, 0, 0);
                holdPressPosition = new Vector3(0, 0, 0);
                holdPressDistance = 0.0f;
                aimSlider.GetComponent<Slider>().value = 0.0f;
            }
        }
    }

    private float AngleBetweenVectors(Vector3 vec1, Vector3 vec2)
    {
        Vector3 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.right, diference) * sign;
    }

    private void viewAimSlider()
    {
        aimSlider.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, aimAngle);
        ball.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, aimAngle);
        holdPressPosition = Input.mousePosition;
        holdPressDistance = Vector3.Distance(firstPressPosition, holdPressPosition);
        if (holdPressDistance> 50.0f) {
            holdPressDistance = 50.0f;
        } else if(holdPressDistance < 0) {
            holdPressDistance = 0.0f;
        }
        aimSlider.GetComponent<Slider>().value = holdPressDistance / 10;
    }


}
