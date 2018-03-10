using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

	private int bulletsRound;
	private int bulletsShooted;
	private float timer;
	private float reloadTime;
	private float delayShootTime;

    public KeyCode bulletInput;
    public KeyCode grenadeInput;

    private void Start()
    {
		bulletsRound = 5;
		bulletsShooted = 0;
		timer = 0.7f;
		reloadTime = 2f;
		delayShootTime = 0.7f;

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
		timer += Time.deltaTime;

		if (Input.GetKeyDown (bulletInput) && bulletsShooted < bulletsRound && timer >= delayShootTime) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction);
			bulletsShooted++;
			timer = 0f;
		}

		if (bulletsShooted >= 5 && timer >= reloadTime) {
			bulletsShooted = 0;
			timer = 0.7f;
		}

		if (Input.GetKeyDown (grenadeInput)) {
			Grenade grenadeToShoot = FindObjectOfType<PoolManager> ().GetGrenade ();
			grenadeToShoot.CurrentGrenadeState = Grenade.GrenadeState.InScene;
			grenadeToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction + Vector3.up);
		}
	}
}

