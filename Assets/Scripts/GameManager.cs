using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;

    // Use this for initialization
    void Start () {

        if (NewPlayerScript.p1 == true)
        {
            GameObject playerInstantation1 = Instantiate(playerPrefab, new Vector3(15f, 5f, 0f), Quaternion.identity);
            playerInstantation1.name = "Player1";
            playerInstantation1.transform.GetChild(0).transform.GetChild(3).GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            playerInstantation1.transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            playerInstantation1.transform.GetChild(0).transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            playerInstantation1.transform.GetChild(0).transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
        }
        if (NewPlayerScript.p2 == true)
        {
            GameObject playerInstantation2 = Instantiate(playerPrefab, new Vector3(15f, 5f, 0f), Quaternion.identity);
            playerInstantation2.name = "Player2";
            playerInstantation2.transform.GetChild(0).transform.GetChild(3).GetComponentInChildren<MeshRenderer>().material.color = Color.green;
            playerInstantation2.transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            playerInstantation2.transform.GetChild(0).transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            playerInstantation2.transform.GetChild(0).transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
        }
        if (NewPlayerScript.p3 == true)
        {
            GameObject playerInstantation3 = Instantiate(playerPrefab, new Vector3(15f, 5f, 0f), Quaternion.identity);
            playerInstantation3.name = "Player3";
            playerInstantation3.transform.GetChild(0).transform.GetChild(3).GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
            playerInstantation3.transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            playerInstantation3.transform.GetChild(0).transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            playerInstantation3.transform.GetChild(0).transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
        }
        if (NewPlayerScript.p4 == true)
        {
            GameObject playerInstantation4 = Instantiate(playerPrefab, new Vector3(15f, 5f, 0f), Quaternion.identity);
            playerInstantation4.name = "Player4";
            playerInstantation4.transform.GetChild(0).transform.GetChild(3).GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
            playerInstantation4.transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            playerInstantation4.transform.GetChild(0).transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            playerInstantation4.transform.GetChild(0).transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
        }

        /*for (int i = 0; i < NewPlayerScript.numberOfPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject playerInstantation1 = Instantiate(playerPrefab, new Vector3(15f, 5f, 0f), Quaternion.identity);
                    playerInstantation1.name = "Player" + i;
                    playerInstantation1.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    break;
                case 1:
                    GameObject playerInstantation2 = Instantiate(playerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
                    playerInstantation2.name = "Player" + i;
                    playerInstantation2.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
                    break;
                case 2:
                    GameObject playerInstantation3 = Instantiate(playerPrefab, new Vector3(7f, 15f, 0f), Quaternion.identity);
                    playerInstantation3.name = "Player" + i;
                    playerInstantation3.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
                    break;
                case 3:
                    GameObject playerInstantation4 = Instantiate(playerPrefab, new Vector3(3f, 15f, 0f), Quaternion.identity);
                    playerInstantation4.name = "Player" + i;
                    playerInstantation4.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
                    break;
            }
        }*/
    }


}
