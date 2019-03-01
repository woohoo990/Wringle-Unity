using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_partcile : MonoBehaviour {

	public ParticleSystem particle;
	public GameObject coin_particle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		// if(other.tag=="Player"){
		// 	Instantiate(particle,coin_particle.transform.position,Quaternion.identity);
		// 	Destroy(this.gameObject);
		// }
	}
}
