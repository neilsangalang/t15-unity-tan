﻿using System.Collections;
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
            GetComponent<AudioSource>().Play();
            GameObject.Find("AimPosition").SendMessage("increaseBall");
            StartCoroutine(destroyGameObject());
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    IEnumerator destroyGameObject()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
