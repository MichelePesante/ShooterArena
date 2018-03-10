using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {
	void Update() {
		if (Input.GetKeyDown (KeyCode.Joystick1Button2)) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position, FindObjectOfType<PlayerInput>().direction);
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			Grenade grenadeToShoot = FindObjectOfType<PoolManager> ().GetGrenade ();
			grenadeToShoot.CurrentGrenadeState = Grenade.GrenadeState.InScene;
			grenadeToShoot.ShootStartPosition (transform.position, FindObjectOfType<PlayerInput>().direction + Vector3.up);
		}
	}
}

