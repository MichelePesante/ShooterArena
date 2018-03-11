using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerScript : MonoBehaviour {

    public static int numberOfPlayers;

    public static bool p1, p2, p3, p4;

    public Text player1text, player2text, player3text, player4text;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) && !p1)
        {
            numberOfPlayers++;
            p1 = true;
            player1text.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button7) && !p2)
        {
            numberOfPlayers++;
            p2 = true;
            player2text.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick3Button7) && !p3)
        {
            numberOfPlayers++;
            p3 = true;
            player3text.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick4Button7) && !p4)
        {
            numberOfPlayers++;
            p4 = true;
            player4text.enabled = true;
        }

        
        Debug.Log(numberOfPlayers);
    }
}
