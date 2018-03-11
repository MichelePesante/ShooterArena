using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerScript : MonoBehaviour {

    public static int numberOfPlayers;

    public static bool p1, p2, p3, p4;

    public static int p1HeadModel, p2HeadModel, p3HeadModel, p4HeadModel;

    public Text player1text, player2text, player3text, player4text;
    public GameObject p1GO, p2GO, p3GO, p4GO;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !p1)
        {
            numberOfPlayers++;
            player1text.gameObject.SetActive(true);
            player1text.color = Color.red;
            p1GO.SetActive(true);
            p1GO.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
            p1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && p1)
        {
            player1text.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !p2)
        {
            numberOfPlayers++;
            player2text.gameObject.SetActive(true);
            player2text.color = Color.red;
            p2GO.SetActive(true);
            p2GO.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
            p2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && p2)
        {
            player2text.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Joystick3Button0) && !p3)
        {
            numberOfPlayers++;
            player3text.gameObject.SetActive(true);
            player3text.color = Color.red;
            p3GO.SetActive(true);
            p3GO.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.green;
            p3 = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick3Button0) && p3)
        {
            player3text.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Joystick4Button0) && !p4)
        {
            numberOfPlayers++;
            player4text.gameObject.SetActive(true);
            player4text.color = Color.red;
            p4GO.SetActive(true);
            p4GO.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.yellow;
            p4 = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick4Button0) && p4)
        {
            player4text.color = Color.green;
        }


        Debug.Log(numberOfPlayers);
    }
}
