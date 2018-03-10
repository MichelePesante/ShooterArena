using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {
	void Update() {
		if (Input.GetKeyDown (KeyCode.A)) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position);
		}
	}
}

