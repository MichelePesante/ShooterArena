using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewPlayerScript : MonoBehaviour {

    public static int numberOfPlayers;

    public static bool P1Join, P2Join, P3Join, P4Join;

    public static int p1HeadModel, p2HeadModel, p3HeadModel, p4HeadModel;

    public Text player1text, player2text, player3text, player4text;
    public GameObject P1GameObject, P2GameObject, P3GameObject, P4GameObject;

    public List<PlayerModelChoose> players = new List<PlayerModelChoose>();

    int i = 0;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !P1Join)
        {
            numberOfPlayers++;
            player1text.gameObject.SetActive(true);
            player1text.color = Color.red;
            P1GameObject.SetActive(true);
            P1GameObject.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
            P1Join = true;
            players.Add(P1GameObject.GetComponent<PlayerModelChoose>());
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) && P1Join)
        {
            player1text.color = Color.green;
            P1GameObject.GetComponent<PlayerModelChoose>().ready = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !P2Join)
        {
            numberOfPlayers++;
            player2text.gameObject.SetActive(true);
            player2text.color = Color.red;
            P2GameObject.SetActive(true);
            P2GameObject.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
            P2Join = true;
            players.Add(P2GameObject.GetComponent<PlayerModelChoose>());
        }
        else if (Input.GetKeyDown(KeyCode.Joystick2Button0) && P2Join)
        {
            player2text.color = Color.green;
            P2GameObject.GetComponent<PlayerModelChoose>().ready = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick3Button0) && !P3Join)
        {
            numberOfPlayers++;
            player3text.gameObject.SetActive(true);
            player3text.color = Color.red;
            P3GameObject.SetActive(true);
            P3GameObject.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.green;
            P3Join = true;
            players.Add(P3GameObject.GetComponent<PlayerModelChoose>());
        }
        else if (Input.GetKeyDown(KeyCode.Joystick3Button0) && P3Join)
        {
            player3text.color = Color.green;
            P3GameObject.GetComponent<PlayerModelChoose>().ready = true;
        }


        if (Input.GetKeyDown(KeyCode.Joystick4Button0) && !P4Join)
        {
            numberOfPlayers++;
            player4text.gameObject.SetActive(true);
            player4text.color = Color.red;
            P4GameObject.SetActive(true);
            P4GameObject.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().material.color = Color.yellow;
            P4Join = true;
            players.Add(P4GameObject.GetComponent<PlayerModelChoose>());
        }
        else if (Input.GetKeyDown(KeyCode.Joystick4Button0) && P4Join)
        {
            player4text.color = Color.green;
            P4GameObject.GetComponent<PlayerModelChoose>().ready = true;
        }

        foreach (PlayerModelChoose player in players)
        {
            if (player.ready == true)
            {
                i++;
            }
        }
        
        if (i == numberOfPlayers && numberOfPlayers != 0)
        {
            
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            i = 0;
        }

        Debug.Log(i);
    }
}
