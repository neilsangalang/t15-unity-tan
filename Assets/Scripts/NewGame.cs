using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void LoadSceneManager()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadSceneOne());
    }

    IEnumerator LoadSceneOne()
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(1);
    }
}
