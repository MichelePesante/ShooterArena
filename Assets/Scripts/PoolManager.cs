using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	int MaxBullet = 20;
	public Bullet Bullet;
	List<Bullet> Bullets;

	void Start () {
		for (int i = 0; i < MaxBullet; i++) {
			Bullets.Add(Instantiate(Bullet));
		}
	}

	void Update () {
		
	}

	public Bullet GetBullet() {
		foreach (Bullet b in Bullets) {
			if (b.CurrentBulletState == Bullet.BulletState.InPool) {
				return Bullet;
			}
		}
	}
}
