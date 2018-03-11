using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

	private int bulletsRound;
	private int bulletsShooted;
	private float timer;
	private float bulletReloadTime;
	private float delayShootTime;

    public float grenadeTimer;
    public int grenades;

    public KeyCode bulletInput;
    public KeyCode grenadeInput;

    private Color projectileColor;

    Animator myAnim;

    private void Start()
    {
        myAnim = transform.parent.GetChild(0).GetComponent<Animator>();

		bulletsRound = 5;
		bulletsShooted = 0;
		timer = 0.7f;
		bulletReloadTime = 2f;
		delayShootTime = 0.7f;

        if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player1")
        {
            bulletInput = KeyCode.Joystick1Button2;
            grenadeInput = KeyCode.Joystick1Button1;
            projectileColor = Color.red;
        }
        else if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player2")
        {
            bulletInput = KeyCode.Joystick2Button2;
            grenadeInput = KeyCode.Joystick2Button1;
            projectileColor = Color.green;
        }
        else if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player3")
        {
            bulletInput = KeyCode.Joystick3Button2;
            grenadeInput = KeyCode.Joystick3Button1;
            projectileColor = Color.yellow;
        }
        else if (gameObject.GetComponentInParent<PlayerInput>().gameObject.name == "Player4")
        {
            bulletInput = KeyCode.Joystick4Button2;
            grenadeInput = KeyCode.Joystick4Button1;
            projectileColor = Color.blue;
        }

    }


    void Update() {
		timer += Time.deltaTime;

		if (Input.GetKeyDown (bulletInput) && bulletsShooted < bulletsRound && timer >= delayShootTime) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction, projectileColor);
			bulletsShooted++;
			timer = 0f;

            myAnim.SetBool("IsAttacking", true);
		}
        else
        {
            myAnim.SetBool("IsAttacking", false);
        }

		if (bulletsShooted >= 5 && timer >= bulletReloadTime) {
			bulletsShooted = 0;
			timer = 0.7f;
		}

		if (Input.GetKeyDown (grenadeInput) && grenades > 0) {
			Grenade grenadeToShoot = FindObjectOfType<PoolManager> ().GetGrenade ();
            grenadeToShoot.gameObject.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;
            grenadeToShoot.CurrentGrenadeState = Grenade.GrenadeState.InScene;
			grenadeToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction + Vector3.up, projectileColor);
            grenades--;
		}

        if (grenades <= 0)
        {
            grenadeTimer += Time.deltaTime;
            if (grenadeTimer >= 5f)
            {
                grenades++;
                grenadeTimer = 0f;
            }
        }

	}
}

