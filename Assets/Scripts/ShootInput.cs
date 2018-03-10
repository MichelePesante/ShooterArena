using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

    public KeyCode bulletInput;
    public KeyCode grenadeInput;
    public string playerName;
    private Color projectileColor;

    private void Start()
    {
        playerName = gameObject.GetComponentInParent<PlayerInput>().gameObject.name;

        if (playerName == "Player0")
        {
            bulletInput = KeyCode.Joystick1Button2;
            grenadeInput = KeyCode.Joystick1Button1;
            projectileColor = Color.red;
        }
        else if (playerName == "Player1")
        {
            bulletInput = KeyCode.Joystick2Button2;
            grenadeInput = KeyCode.Joystick2Button1;
            projectileColor = Color.green;
        }
        else if (playerName == "Player2")
        {
            bulletInput = KeyCode.Joystick3Button2;
            grenadeInput = KeyCode.Joystick3Button1;
            projectileColor = Color.yellow;
        }
        else if (playerName == "Player3")
        {
            bulletInput = KeyCode.Joystick4Button2;
            grenadeInput = KeyCode.Joystick4Button1;
            projectileColor = Color.blue;
        }

    }


    void Update() {
		if (Input.GetKeyDown (bulletInput)) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction);
            bulletToShoot.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;
		}

		if (Input.GetKeyDown (grenadeInput)) {
			Grenade grenadeToShoot = FindObjectOfType<PoolManager> ().GetGrenade ();
			grenadeToShoot.CurrentGrenadeState = Grenade.GrenadeState.InScene;
			grenadeToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction + Vector3.up);
            grenadeToShoot.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;
        }
	}
}

