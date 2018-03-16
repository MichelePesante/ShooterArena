using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    Vector3 startPos;

	public State PlayerState;

    public int startingLives;
    [HideInInspector]
    public int lives;
	// Use this for initialization
	void Start () {
        lives = startingLives;
		PlayerState = State.IsGrounded;
        if (gameObject.name == "Player1")
        {
            startPos = new Vector3(5f, 13f, 0f);
        }
        else if (gameObject.name == "Player2")
        {
            startPos = new Vector3(32f, 13f, 0f);
        }
        else if (gameObject.name == "Player3")
        {
            startPos = new Vector3(5f, 1f, 0f);
        }
        else if (gameObject.name == "Player4")
        {
            startPos = new Vector3(32f, 1f, 0f);
        }
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
        lives--;
        if (lives > 0)
        {
            Invoke("Respawn", 1f);
        }
        
    }

    private void Respawn()
    {
        transform.position = startPos;
        gameObject.SetActive(true);
    }

	public enum State 
	{
		IsGrounded = 0,
		IsJumping = 1,
		IsFalling = 2,
		IsDead = 3
	}
}
