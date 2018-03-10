using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private float movementSpeed;
	private float jumpSpeed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		movementSpeed = 0.2f;
		jumpSpeed = 20f;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * movementSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * movementSpeed;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			rb.velocity = Vector3.up * jumpSpeed;
		}
	}
}
