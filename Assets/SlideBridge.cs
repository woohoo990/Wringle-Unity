using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBridge : MonoBehaviour {
	[Header("Slider Property")]
	[Range(0,10)]
	public float speed;
	[Range(0,50)]
	public int distance;
	private int count = 0;
	private float startPosition;
	private float endPosition;
	private bool reverse=false;
	private bool GameStarted = false;
	public bool Sink  = false;
	private bool StopMoving = false;
	// Use this for initialization
	void Start () {
		startPosition = transform.position.x;
		endPosition = transform.position.x+distance;
		GameStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		float xMove = speed*Time.deltaTime*2;
		
		//Forward Movement
		if(!StopMoving){
			if((transform.position.x < endPosition) && !reverse){
			transform.Translate(xMove,0,0);
			}
			else{
				reverse = true;
			}

			//Reverse Movement
			if((transform.position.x > startPosition) && reverse){
				transform.Translate(-xMove,0,0);
			}
			else{
				reverse = false;
			}
		}else{
			transform.Translate(0,-0.2f,0);
		}
	}
	void OnDrawGizmosSelected()
	{
		float posY = transform.position.y;
		float width = gameObject.GetComponent<PolygonCollider2D>().bounds.extents.x;
		if(!GameStarted){
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(new Vector3(transform.position.x-width,posY,0), new Vector3(transform.position.x+distance+width, transform.position.y,0));
		}
		else{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(new Vector3(startPosition-width,posY,0), new Vector3(endPosition+width, posY,0));
		}
		
	}

	//Setting Parent
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "Player"){
			other.transform.SetParent(transform);
			if(Sink){
				StopMoving = true;
			}
		}
	}

	//Setting free from Parent
	void OnCollisionExit2D(Collision2D other)
	{
		if(other.transform.tag == "Player"){
			other.transform.SetParent(null);
		}
	}
	
}
