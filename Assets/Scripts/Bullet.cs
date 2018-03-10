using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float bulletSpeed;

	private BulletState CurrentBulletState;

	// Use this for initialization
	void Start () {
		CurrentBulletState = BulletState.InPool;
		bulletSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public enum BulletState {
		InPool = 0,
		InScene = 1
	}
}
