using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    Rigidbody ballRigidbody;
    public GameObject aimPosition;

    // Use this for initialization
    void Start () {
        ballRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bottom")
        {
            ballRigidbody.isKinematic = true;
            aimPosition.GetComponent<Transform>().position = transform.position;
            aimPosition.GetComponent<AimScript>().aimingEnabled = true;
            GameObject.Find("Map").GetComponent <MapScript>().level++;
            GameObject.Find("Map").SendMessage("generateLine");
        }

    }
}
