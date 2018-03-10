using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	public GrenadeState CurrentGrenadeState;

	void Start () {
		CurrentGrenadeState = GrenadeState.InPool;
	}
		
	void Update () {

	}

	public enum GrenadeState {
		InPool = 0,
		InScene = 1
	}
}
