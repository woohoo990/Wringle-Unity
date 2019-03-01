using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEmovement : MonoBehaviour {
	int count;
	int temp=0;
	SpriteRenderer sprite;
	float speed=0.5f;
	public Animator animator;
	bool scene4=false;
	
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		sprite = GetComponent<SpriteRenderer>();
		if(SceneManager.GetActiveScene().name=="Level4"){
			scene4 = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Walking();
	}

	void Walking(){
		animator.SetBool("EnemyState",false);
		Vector2 originLeft = new Vector2(transform.position.x-1f, transform.position.y);
		Vector2 originRight = new Vector2(transform.position.x+1f, transform.position.y);		
		RaycastHit2D raycast;
		

		if(sprite.flipX == true){
			raycast = Physics2D.Raycast(originLeft,Vector2.left,20);
			if(raycast.rigidbody == GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>())
				follow();

			else {
				walk_1();				
			}
		}
		

		else{
			raycast = Physics2D.Raycast(originRight,-Vector2.left,20);
			// print(raycast.rigidbody);
			if(raycast.rigidbody == GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>())
				follow();

			else{
				walk_2();
			}
			
		}


		transform.rotation = new Quaternion(0,0,0,0);	
	}

	void follow(){
		animator.SetBool("EnemyState",true);
		
		temp = 101;
		count = 3;
		

		if(sprite.flipX == true){
			count = 0;
			temp = 0;
			if(scene4){
				transform.Translate(-0.17f*speed,0,0);
			}
			else{
				transform.Translate(-0.4f*speed,0,0);
			}
			
		}
		else{
			count=2;
			temp=100;
			if(scene4){
				transform.Translate(0.17f*speed,0,0);
			}
			else{
				transform.Translate(0.4f*speed,0,0);
			}
			
		}
	}

	void walk_1(){
		if(count==0){
			if(scene4==true){
				transform.Translate(-0.03f*speed,0,0);
				temp++;
			}
			else{
				transform.Translate(-0.1f*speed,0,0);
				temp++;
			}
		}

		if(scene4==true){
			if(temp==500){
				count=2;
				sprite.flipX = false;
			}
		}
		else{
			if(temp==100){
				count=2;
				sprite.flipX = false;
			}
		}
	}


	void walk_2(){
		if(count==2){
			if(scene4==true){
				transform.Translate(0.03f*speed,0,0);
				temp--;
			}
			else{
				transform.Translate(0.1f*speed,0,0);
				temp--;
			}
		}

		if(temp==0){
			count=0;
			sprite.flipX = true;
		}
	}
}
