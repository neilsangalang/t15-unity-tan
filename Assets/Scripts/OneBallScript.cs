using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBallScript : MonoBehaviour
{
    Rigidbody oneBallRigidbody;
    // Use this for initialization
    void Start()
    {
        oneBallRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "balls")
        {
            GameObject.Find("AimPosition").SendMessage("increaseBall");
            Destroy(gameObject);
        }
    }
}
