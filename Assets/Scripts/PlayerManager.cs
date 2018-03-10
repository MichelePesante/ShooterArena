using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int numberOfPlayers = 4;

    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject playerInstantation1 = Instantiate(playerPrefab, new Vector3(15f, 5f, 0f), Quaternion.identity);
                    playerInstantation1.name = "Player" + i;
                    break;
                case 1:
                    GameObject playerInstantation2 = Instantiate(playerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
                    playerInstantation2.name = "Player" + i;
                    break;
                case 2:
                    GameObject playerInstantation3 = Instantiate(playerPrefab, new Vector3(7f, 15f, 0f), Quaternion.identity);
                    playerInstantation3.name = "Player" + i;
                    break;
                case 3:
                    GameObject playerInstantation4 = Instantiate(playerPrefab, new Vector3(3f, 15f, 0f), Quaternion.identity);
                    playerInstantation4.name = "Player" + i;
                    break;

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
