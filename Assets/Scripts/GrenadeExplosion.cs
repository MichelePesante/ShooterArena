using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {

    float timer;
    float explosionForce = 1.7f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponentInParent<Grenade>().CurrentGrenadeState == Grenade.GrenadeState.InScene)
        {
            timer += Time.deltaTime;
        }
        else if (gameObject.GetComponentInParent<Grenade>().CurrentGrenadeState == Grenade.GrenadeState.InPool)
        {
            timer = 0;
        }
        if (timer >= 1f)
        {
            GetComponent<SphereCollider>().radius += explosionForce;
        }
        if (timer >= 1.25f)
        {
            GetComponent<SphereCollider>().radius = 0.5f;
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 dir = other.transform.position - transform.position;
            dir.Normalize();
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir * 75f, ForceMode.Impulse);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1500f, 1500f, 0f));
        }
    }
}
