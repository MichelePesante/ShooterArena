using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	private int maxBullets = 20;
	private int maxGrenades = 12;
	private List<Bullet> bullets;
	private List<Grenade> grenades;

	public Bullet Bullet;
	public Grenade Grenade;

	void Start () {
		for (int i = 0; i < maxBullets; i++) {
			bullets.Add(Instantiate(Bullet));
		}
		for (int i = 0; i < maxGrenades; i++) {
			grenades.Add (Instantiate (Grenade));
		}
	}

	void Update () {
		
	}

	public Bullet GetBullet() {
		foreach (Bullet bullet in bullets) {
			if (bullet.CurrentBulletState == Bullet.BulletState.InPool) {
				return Bullet;
			}
		}
		return null;
	}

	public Grenade GetGrenade() {
		foreach (Grenade grenade in grenades) {
			if (grenade.CurrentGrenadeState == Grenade.GrenadeState.InPool) {
				return Grenade;
			}
		}
		return null;
	}
}
