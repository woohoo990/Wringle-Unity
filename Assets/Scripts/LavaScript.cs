using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {
	float incr=0.02f;
	public bool RaiseLava;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(RaiseLava){
			this.transform.Translate(0,incr,0);
			incr = incr + 0.0000005f;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Player"){
			HealthBar.health = 0;
		}		
	}
}
