using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {
	private Rigidbody2D rigidbody;
	[Header("Jump Properties")]
	public float jumpForce;
	private bool isGrounded;
	public Transform feetPos;
	public float checkRadius;
	public Vector2 size;
	public LayerMask whatisGround;
	private bool isJumping;
	private int jumpingTimeCounter;
	public float jumpingTime;
	[Header("Upgrade Jump")]
	public bool UnlockTripleJump;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapBox(feetPos.position, size, 0, whatisGround);

		//Single Jump
		if(isGrounded == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))){		
			jumpingTimeCounter = 2; //Number of Jumps in air
			rigidbody.velocity = Vector2.up * jumpForce; //Single Jump Distance Controller
		}

		// Unlocking Triple Jump
		if(UnlockTripleJump){
			//Triple Jump
			if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !isGrounded){
				if(jumpingTimeCounter > 0){
					rigidbody.velocity = Vector2.up *(jumpForce); //Triple Jump Distance Controller
					jumpingTimeCounter -= 1;
				}
				else{
					isJumping = false;
				}
			}

			//Exiting Jump
			if((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))){
				isJumping = false;
			}

			//Falling Jump Speed
			if(rigidbody.velocity.y<0){
				rigidbody.velocity += Vector2.up * Physics2D.gravity.y*(1.15f)*Time.deltaTime;
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(feetPos.position,size);
	}
}
