using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float bulletSpeed;
	private Vector3 direction;
	private float bulletForce;

	public BulletState CurrentBulletState;

	// Use this for initialization
	void Start () {
		CurrentBulletState = BulletState.InPool;
		bulletSpeed = 0.9f;
		bulletForce = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentBulletState == BulletState.InPool) 
		{
			transform.position = FindObjectOfType<PoolManager> ().PoolManagerPosition;
		}
		if (CurrentBulletState == BulletState.InScene) 
		{
			transform.position += direction * bulletSpeed;
		} 
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().velocity = direction * bulletForce;
        }


        CurrentBulletState = BulletState.InPool;


    }

    public enum BulletState {
		InPool = 0,
		InScene = 1
	}

	public void ShootStartPosition(Vector3 _startPosition, Vector3 _direction, Color _color) 
	{
		direction = _direction;
		transform.position = _startPosition;
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = _color;
    }
}
