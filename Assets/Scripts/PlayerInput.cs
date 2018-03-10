using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private float movementSpeed;
	private float jumpSpeed;
	public Vector3 direction;

	private Rigidbody rb;
	private bool isRotateRight;

    public string horizontalInput;
    public KeyCode jumpInput;
    public string[] controllers;

	// Use this for initialization
	void Start () {
		movementSpeed = 0.2f;
		jumpSpeed = 20f;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
		direction = Vector3.right;
		isRotateRight = true;
        controllers = Input.GetJoystickNames();


        if (gameObject.name == "Player0")
        {
            horizontalInput = "Horizontal";
            jumpInput = KeyCode.Joystick1Button0; 
                }
        else if (gameObject.name == "Player1")
        {
            horizontalInput = "Horizontal2";
            jumpInput = KeyCode.Joystick2Button0;
        }
        else if (gameObject.name == "Player2")
        {
            horizontalInput = "Horizontal3";
            jumpInput = KeyCode.Joystick3Button0;
        }
        else if (gameObject.name == "Player3")
        {
            horizontalInput = "Horizontal4";
            jumpInput = KeyCode.Joystick4Button0;
        }
    }
	
	// Update is called once per frame
	void Update () {




		if (Input.GetAxis (horizontalInput) == -1) {
			direction = Vector3.left;
			transform.position += direction * movementSpeed;
			if (isRotateRight) {
				transform.Rotate (0f, 180f, 0f);
				isRotateRight = false;
			}
		}
		if (Input.GetAxis (horizontalInput) == 1) {
			direction = Vector3.right;
			transform.position += direction * movementSpeed;
			if (!isRotateRight) {
				transform.Rotate (0f, -180f, 0f);
				isRotateRight = true;
			}
		}
		if (Input.GetKeyDown (jumpInput)) {
			rb.velocity = Vector3.up * jumpSpeed;
		}
	}
}
