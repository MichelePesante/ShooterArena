using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	private int maxBullets = 20;
	private int maxGrenades = 12;
	private List<Bullet> bullets = new List<Bullet>();
	private List<Grenade> grenades = new List<Grenade>();

	public Bullet BulletPrefab;
	public Grenade GrenadePrefab;
	public Vector3 PoolManagerPosition;

	void Awake() 
	{
		PoolManagerPosition = transform.position;
	}

	void Start () {
		for (int i = 0; i < maxBullets; i++) {
			Bullet bulletToAdd = (Instantiate (BulletPrefab));
			bullets.Add (bulletToAdd);
		}
		for (int i = 0; i < maxGrenades; i++) {
			Grenade grenadeToAdd = (Instantiate (GrenadePrefab));
			grenades.Add (grenadeToAdd);
		}
	}

	void Update () {
		
	}

	public Bullet GetBullet() {
		foreach (Bullet bullet in bullets) {
			if (bullet.CurrentBulletState == Bullet.BulletState.InPool) {
				return bullet;
			}
		}
		return null;
	}

	public Grenade GetGrenade() {
		foreach (Grenade grenade in grenades) {
			if (grenade.CurrentGrenadeState == Grenade.GrenadeState.InPool) {
				return grenade;
			}
		}
		return null;
	}
}
