using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	private float grenadeSpeed;
	private bool hasBeenShooted;
	private Vector3 direction;
	private Rigidbody rb;

	public GrenadeState CurrentGrenadeState;

	void Start () {
		CurrentGrenadeState = GrenadeState.InPool;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
		grenadeSpeed = 15f;
		hasBeenShooted = false;
	}
		
	void Update () {
		if (CurrentGrenadeState == GrenadeState.InPool) 
		{
			transform.position = FindObjectOfType<PoolManager> ().PoolManagerPosition;
			hasBeenShooted = false;
		}
		if (CurrentGrenadeState == GrenadeState.InScene && hasBeenShooted == false) 
		{
			rb.velocity = direction * grenadeSpeed;
			hasBeenShooted = true;
		} 
	}

	void OnCollisionEnter (Collision collision) {
		CurrentGrenadeState = GrenadeState.InPool;
	}

	public enum GrenadeState {
		InPool = 0,
		InScene = 1
	}

	public void ShootStartPosition(Vector3 _startPosition, Vector3 _direction) 
	{
		direction = _direction;
		transform.position = _startPosition;
	}
}
