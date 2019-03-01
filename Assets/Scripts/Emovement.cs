using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emovement : MonoBehaviour {
	int count;
	int temp=0;
	SpriteRenderer sprite;
	float speed=0.5f;
	
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		swing();
	}

	void swing(){
		
		if(temp==0){
			count=0;
			sprite.flipX = true;
		}
			
		else{
			if(temp==100){
				count=2;
				sprite.flipX = false;
			}
		}

		
			
		
		
		if(count==0){
			transform.Translate(-0.1f*speed,0,0);
			temp++;			
		}
			

		if(count==2){
			transform.Translate(0.1f*speed,0,0);
			temp--;
		}
			

		transform.rotation = new Quaternion(0,0,0,0);
		
	}
}
