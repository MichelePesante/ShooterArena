﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	private float grenadeSpeed;
	private bool hasBeenShooted;
	private Vector3 direction;
	private Rigidbody rb;
	private float explosionForce;
	private float timer;

	public GrenadeState CurrentGrenadeState;

	void Start () {
		CurrentGrenadeState = GrenadeState.InPool;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
		grenadeSpeed = 15f;
		explosionForce = 12f;
		hasBeenShooted = false;
		timer = 0f;
	}
		
	void Update () {
		if (CurrentGrenadeState == GrenadeState.InPool) 
		{
			transform.position = FindObjectOfType<PoolManager> ().PoolManagerPosition;
			hasBeenShooted = false;
			ReduceExplosionRadius ();
		}
		if (CurrentGrenadeState == GrenadeState.InScene) 
		{
			timer += Time.deltaTime;
			if (hasBeenShooted == false) {
				rb.velocity = direction * grenadeSpeed;
				hasBeenShooted = true;
			}
			if (timer >= 1.5f) {
				Explode ();
				CurrentGrenadeState = GrenadeState.InPool;
				timer = 0f;
			}
		} 
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

	public void Explode()
	{
		for (int i = 0; i < transform.childCount; i++) 
		{	
			if (transform.GetChild(i).name == "Explosion")
				transform.GetChild(i).localScale += new Vector3 (0f, explosionForce, 0f);
			if (transform.GetChild (i).name == "Graphic")
				transform.GetChild (i).GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	public void ReduceExplosionRadius() {
		for (int i = 0; i < transform.childCount; i++) 
		{	
			if (transform.GetChild(i).name == "Explosion")
				transform.GetChild(i).localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			if (transform.GetChild (i).name == "Graphic")
				transform.GetChild (i).GetComponent<MeshRenderer> ().enabled = true;
		}
	}
}
