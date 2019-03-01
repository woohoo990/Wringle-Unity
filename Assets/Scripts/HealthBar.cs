using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
	public static float health = 100;
	public GameObject spawn;
	public Slider slider;
	public ParticleSystem deathParticle;
	// Use this for initialization
	void Start () {
		slider.value=100;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <=0){
				this.gameObject.transform.localScale= new Vector3(0,0,1);
				this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
				Instantiate(deathParticle,transform.GetChild(0).transform.position,Quaternion.identity);
				slider.value=0;
				print("died");
				StartCoroutine(GameOver());
		}
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "enemy" || other.gameObject.tag == "senemy"){
			health = health-25;
			slider.value =health;
		}
		if(other.gameObject.tag == "GreenMonster"){
			health = health-65;
			slider.value =health;
		}
		
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		slider.value=100;
		health = 100;
		this.gameObject.transform.localScale= new Vector3(0.35f,0.35f,1);
		this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		this.gameObject.transform.position = spawn.transform.position;
	}
}
