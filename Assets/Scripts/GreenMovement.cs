using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMovement : MonoBehaviour {
	Animator animator;
	int temp=0;
	int count;
	float speed=0.5f;
	bool finish;
	int i=0;
	int j=0;
	// Use this for initialization
	void Start () {
		finish = false;
		animator = GetComponent<Animator>();
		animator.SetBool("State",true);
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(1,0,0);
		eatYou();
			
			
	}

	void eatYou(){
		if(temp==0){

			if(j>=0 && j<=30){
				count=3;
				j++;
			}
			if(j>=31 && j<=430){
				animator.SetBool("State",true);				
				j++;
			}

			if(j>=431 && j<=499){
				animator.SetBool("State",false);
				j++;				
			}

			if(j==500){
				count=0;
				j=0;
			}
			
		}
			

		if(temp==30){
			if(i>=0 && i<=399){
				count=3;
				i++;
			}


			if(i==400){
				count=2;
				i=0;
			}
		}
			
		
		
		if(count==0){
			transform.Translate(0,-0.1f*speed,0);
			temp++;
		}
			

		if(count==2){
			transform.Translate(0,0.1f*speed,0);
			temp--;
		}
		
	}
}