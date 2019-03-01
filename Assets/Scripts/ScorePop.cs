using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePop : MonoBehaviour {
	
	// HealthBar healthBar;
	float bhealth;
	public GameObject score;
	GameObject star1;
	GameObject star2;
	GameObject star3;
	GameObject LS1;
	GameObject LS2;
	GameObject LS3;
    Text popCoinText;

	void Start()
	{
		bhealth = HealthBar.health;
		//score = GameObject.Find("ScorePopUp");
		star1 = score.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;
		star2 = score.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject;
		star3 = score.transform.GetChild(0).gameObject.transform.GetChild(7).gameObject;
        popCoinText = score.transform.GetChild(0).transform.GetChild(9).GetComponent<Text>();
	}
	void Update()
	{
		// bhealth = HealthBar.health; 
		// if(bhealth >=1 && bhealth<=30){
		// 	LS2.SetActive(false);
		// 	LS3.SetActive(false);
		// }
				
		
		// else if(bhealth>=31 && bhealth<=99){
		// 		LS3.SetActive(false);
		// 	}
				
		// else if(bhealth==100){
		// 		LS1.SetActive(true);
		// 		LS2.SetActive(true);
		// 		LS3.SetActive(true);
		// 	}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.FindWithTag("Player").GetComponent<Hmovement>().enabled = false;
		GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().simulated = false;
		GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = false;
		
		if(other.tag == "Player"){
		bhealth = HealthBar.health;
		popCoinText.text = Hmovement.coinCount.ToString();

		score.SetActive(true);
			
			if(bhealth >=1 && bhealth<=30)
				star1.SetActive(true);
			else if(bhealth>=31 && bhealth<=99){
				star1.SetActive(true);
				star2.SetActive(true);
			}
				
			else if(bhealth==100){
				star1.SetActive(true);
				star2.SetActive(true);
				star3.SetActive(true);
			}
				
		}
	}
}
