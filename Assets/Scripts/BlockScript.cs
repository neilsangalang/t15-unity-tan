using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int HP = 0;
    public GameObject explosion;
    Rigidbody blockRigidbody;

    // Use this for initialization
    void Start () {
        blockRigidbody = GetComponent<Rigidbody>();
        HP = GameObject.Find("Map").GetComponent<MapScript>().level;
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            gameObject.GetComponent<AudioSource>().Play();
            reduceHP();
        }
    }

    void reduceHP()
    {
        HP--;
        if (HP < 1)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            explosion = Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(destroyGameObject());
        }
    }

    IEnumerator destroyGameObject()
    {
        yield return new WaitForSeconds(1);
        Destroy(explosion);
        Destroy(gameObject);
    }
}
