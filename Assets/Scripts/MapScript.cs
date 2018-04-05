using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapScript : MonoBehaviour {

    public GameObject Block;
    public GameObject OneBall;
    public GameObject Level;
    public int level = 0;
    int[] boxLine;

    // Use this for initialization
    void Start () {
        generateLine();
	}

    void Update() {
        gameStatus();
    }
	
    int[] randomNextLine()
    {
        boxLine = new int[7];
        int boxCounter = 0;

        for(int x=0; x<boxLine.Length; x++)
        {
           if(boxCounter == 5)
            {
                boxLine[x] = 0;
            }
            else if ( boxCounter< x - 6 || Random.Range(1, 100)<(50 -50*(boxCounter/4)) )
            {
                boxCounter++;
                boxLine[x] = 1;
            }
            else
            {
                boxLine[x] = 0;
            }
        }
        foreach(var box in boxLine)
        {
            Debug.Log(box);
        }

        return boxLine;
    }

    void generateLine()
    {
        int[] nextLine = randomNextLine();
        int oneBall = 1;
        for (int x=0; x<nextLine.Length; x++)
        {
            if (oneBall==1 && (nextLine.Length-x==1 || Random.Range(1, 100) < 30))
            {
                oneBall = 0;
                GameObject nextBox = Instantiate(OneBall, new Vector3(x * 1.75f - 9.75f, 19.00f, 4.5f), Quaternion.identity) as GameObject;
                nextBox.transform.parent = GameObject.Find("Map").transform;
            }
            else if(nextLine[x] == 1)
            {
                GameObject nextBox = Instantiate(Block, new Vector3(x*1.75f - 9.75f, 19.00f, 4.5f), Quaternion.identity) as GameObject;
                nextBox.transform.parent = GameObject.Find("Map").transform;
            }
            
        }
        moveLineDown();
    }
    
    void moveLineDown()
    {
        foreach (Transform child in transform)
        {
            child.position = Vector3.MoveTowards(child.position, new Vector3(child.position.x, child.position.y -1.75f, child.position.z), 100*Time.deltaTime );
        }
        Level.GetComponent<Text>().text = "Level: " + level;

    }

    void gameStatus()
    {
        foreach (Transform child in transform)
        {
            if (Vector3.Distance(child.position, GameObject.Find("Bottom").transform.position) <= 3)
            {
                Debug.Log("Game Over!");
                SceneManager.LoadScene(2);
            }
        }
    }
}
