using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : MonoBehaviour {
	bool isMove = false;
	bool isPlayerExiting = false;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(isMove && !isPlayerExiting){
			GameObject.Find("Lava").GetComponent<LavaScript>().enabled = false;
			this.transform.Translate(-0.1f,0,0);
			player.GetComponent<Hmovement>().enabled = false;
			player.GetComponent<JumpScript>().enabled = false;
			player.transform.rotation = new Quaternion(0, 0, 0, 0);
		}
		else if (isMove==false && isPlayerExiting){
			player.GetComponent<Hmovement>().enabled = true;
			player.GetComponent<JumpScript>().enabled = true;
			isPlayerExiting = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag=="Ground"){
			print("Ground");
			isMove = false;
			isPlayerExiting = true;
			other.transform.GetComponent<Rigidbody2D>().isKinematic = true;
		}
		if(isPlayerExiting== false){
		print("Got it");
			if(other.transform.tag=="Player"){
				other.transform.SetParent(transform);
				print("Player");
				isMove = true;
			}
		}
		
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.transform.tag == "Player"){
			other.transform.SetParent(null);
		}
	}
	
}
