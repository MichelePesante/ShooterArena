using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

    public KeyCode bulletInput;
    public KeyCode grenadeInput;

    private void Start()
    {
        if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player0")
        {
            bulletInput = KeyCode.Joystick1Button2;
            grenadeInput = KeyCode.Joystick1Button1;
        }
        else if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player1")
        {
            bulletInput = KeyCode.Joystick2Button2;
            grenadeInput = KeyCode.Joystick2Button1;
        }
        else if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player2")
        {
            bulletInput = KeyCode.Joystick3Button2;
            grenadeInput = KeyCode.Joystick3Button1;
        }
        else if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player3")
        {
            bulletInput = KeyCode.Joystick4Button2;
            grenadeInput = KeyCode.Joystick4Button1;
        }

    }


    void Update() {
		if (Input.GetKeyDown (bulletInput)) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position, FindObjectOfType<PlayerInput>().direction);
		}

		if (Input.GetKeyDown (grenadeInput)) {
			Grenade grenadeToShoot = FindObjectOfType<PoolManager> ().GetGrenade ();
			grenadeToShoot.CurrentGrenadeState = Grenade.GrenadeState.InScene;
			grenadeToShoot.ShootStartPosition (transform.position, FindObjectOfType<PlayerInput>().direction + Vector3.up);
		}
	}
}

