using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class followme : MonoBehaviour {

	GameObject player;
	public GameObject startPoint;
	public GameObject endPoint;
	float y,z;
	float spx, epx;
	float playerx;

	
	// Use this for initialization
	void Start () {
		spx = startPoint.transform.position.x;
		epx = endPoint.transform.position.x;
		y = transform.position.y;
		z = transform.position.z; 
		player = GameObject.FindWithTag("Player");

		
	}
	
	// Update is called once per frame
	void Update () {
		playerx = player.transform.position.x;
		if(distance()>=5 && distance2()>=5){
			transform.position = new Vector3(playerx,y,z);
			// StartCoroutine(smooth2());
		}
		else{
			if(distance()<=5 && distance2()>=5){
				// StartCoroutine(smooth());
				transform.position = new Vector3(spx,y,z);
			}
				
				else if(distance()>=5 && distance2()<=5)
					transform.position = new Vector3(epx,y,z);				
		}
		

		//Scene Change Shortcut
		if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}

		if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.E)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
		}
	}

	float distance(){
		float dis = playerx - spx;
		
		return dis;
	}

	float distance2(){
		float dis = epx - playerx;
		
		return dis;
	}

	IEnumerator smooth(){
		if(distance()<=5){
			transform.position = new Vector3(spx,y,z);
		}

		else if(distance()>=5){
			for(float i=0; i<=1; i+=0.01f){
			transform.position = Vector3.Lerp(new Vector3(playerx,y,z),new Vector3(spx,y,z),i);
			yield return Camera.main;
		 }
		}
		
		
	}

	// IEnumerator smooth2(){
		
	// 	for(float i=0; i<=1; i+=0.01f){
	// 		transform.position = Vector3.Lerp(new Vector3(spx,y,z),new Vector3(playerx,y,z),i);
	// 		yield return Camera.main;
	// 	}
		
	// }

}
