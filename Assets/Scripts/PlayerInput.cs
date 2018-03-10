using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private float movementSpeed;
	private float jumpSpeed;
	public Vector3 direction;
	private bool isJumping;

	private Rigidbody rb;
	private bool isRotateRight;

    private string horizontalInput;
    private string verticalInput;
    private KeyCode jumpInput;

	void Start () {
		isJumping = false;
		movementSpeed = 0.2f;
		jumpSpeed = 20f;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
		direction = Vector3.right;
		isRotateRight = true;


        if (gameObject.name == "Player0")
        {
            horizontalInput = "Horizontal";
            verticalInput = "Vertical";
            jumpInput = KeyCode.Joystick1Button0; 
        }
        else if (gameObject.name == "Player1")
        {
            horizontalInput = "Horizontal2";
            verticalInput = "Vertical2";
            jumpInput = KeyCode.Joystick2Button0;
        }
        else if (gameObject.name == "Player2")
        {
            horizontalInput = "Horizontal3";
            verticalInput = "Vertical3";
            jumpInput = KeyCode.Joystick3Button0;
        }
        else if (gameObject.name == "Player3")
        {
            horizontalInput = "Horizontal4";
            verticalInput = "Vertical4";
            jumpInput = KeyCode.Joystick4Button0;
        }
    }

	void Update () {

		if (Input.GetAxis (horizontalInput) == -1) 
		{
			direction = Vector3.left;
			transform.position += direction * movementSpeed;
			if (isRotateRight) 
			{
				transform.Rotate (0f, 180f, 0f);
				isRotateRight = false;
			}
		}
		if (Input.GetAxis (horizontalInput) == 1) 
		{
			direction = Vector3.right;
			transform.position += direction * movementSpeed;
			if (!isRotateRight) 
			{
				transform.Rotate (0f, -180f, 0f);
				isRotateRight = true;
			}
		}
		if (Input.GetKeyDown (jumpInput) && !isJumping) 
		{
			rb.velocity = Vector3.up * jumpSpeed;
			isJumping = true;
		}
        if (Input.GetAxis (verticalInput) == 1)
        {
            Physics.IgnoreLayerCollision(8, 9, true);
        }
        else
        {
            Physics.IgnoreLayerCollision(8, 9, false);
        }
	}

	void OnCollisionEnter(Collision _collision) 
	{
		if (_collision.gameObject.tag == "Ground" && isJumping) 
		{
			isJumping = false;
		}
	}
}
