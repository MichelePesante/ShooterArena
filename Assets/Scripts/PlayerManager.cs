using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Invoke("Respawn", 1f);
    }

    private void Respawn()
    {
        transform.position = startPos;
        gameObject.SetActive(true);
    }
}
