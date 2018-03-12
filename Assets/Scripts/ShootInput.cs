using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {


    public int availableBullets;
    public float bulletShootDelay;
    public float bulletReloadTime;
    float bulletTimer;
    float grenadeTimer;


    public float grenadeReloadTime;
    public int grenades;

    public KeyCode bulletInput;
    public KeyCode grenadeInput;

    private Color projectileColor;

    Animator myAnim;

    private void Start()
    {
        myAnim = transform.parent.GetChild(0).GetComponent<Animator>();

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
		bulletTimer += Time.deltaTime;
        grenadeTimer += Time.deltaTime;
        
		if (Input.GetKeyDown (bulletInput) && availableBullets != 0 && bulletTimer >= bulletShootDelay) {
			Bullet bulletToShoot = FindObjectOfType<PoolManager> ().GetBullet ();
			bulletToShoot.CurrentBulletState = Bullet.BulletState.InScene;
			bulletToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction, projectileColor);
            availableBullets--;
			bulletTimer = 0f;

            myAnim.SetBool("IsAttacking", true);
		}
        else
        {
            myAnim.SetBool("IsAttacking", false);
        }

        if (availableBullets <= 0 && bulletTimer >= bulletReloadTime)
        {
            availableBullets = 7;
            bulletTimer = 0f;
        }

		if (Input.GetKeyDown (grenadeInput) && grenades >= 0) {
			Grenade grenadeToShoot = FindObjectOfType<PoolManager> ().GetGrenade ();
            grenadeToShoot.gameObject.GetComponentInChildren<MeshRenderer>().material.color = projectileColor;
            grenadeToShoot.CurrentGrenadeState = Grenade.GrenadeState.InScene;
			grenadeToShoot.ShootStartPosition (transform.position, gameObject.GetComponentInParent<PlayerInput>().direction + Vector3.up, projectileColor);
            grenades--;
		}

        if (grenades <= 0)
        {
            if (grenadeTimer >= grenadeReloadTime)
            {
                grenades++;
                grenadeTimer = 0f;
            }
        }

	}
}

