using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private float movementSpeed;
	private float jumpSpeed;

	private Rigidbody rb;
	private Vector3 direction;
	private bool isRotateRight;

	// Use this for initialization
	void Start () {
		movementSpeed = 0.2f;
		jumpSpeed = 20f;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
		isRotateRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") == -1) {
			direction = Vector3.left;
			transform.position += direction * movementSpeed;
			if (isRotateRight) {
				transform.Rotate (0f, 180f, 0f);
				isRotateRight = false;
			}
		}
		if (Input.GetAxis ("Horizontal") == 1) {
			direction = Vector3.right;
			transform.position += direction * movementSpeed;
			if (!isRotateRight) {
				transform.Rotate (0f, -180f, 0f);
				isRotateRight = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button0)) {
			rb.velocity = Vector3.up * jumpSpeed;
		}
	}
}
