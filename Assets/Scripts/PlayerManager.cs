using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static int numberOfPlayers;

    bool p1, p2, p3, p4;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) && !p1)
        {
            numberOfPlayers++;
            p1 = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button7) && !p2)
        {
            numberOfPlayers++;
            p2 = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick3Button7) && !p3)
        {
            numberOfPlayers++;
            p3 = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick4Button7) && !p4)
        {
            numberOfPlayers++;
            p4 = true;
        }

        Debug.Log(numberOfPlayers);
    }
}
