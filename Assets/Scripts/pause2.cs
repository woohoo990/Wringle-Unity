using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class pause2 : MonoBehaviour {

	static bool isPaused = false;
	GameObject PauseUI;
	public GameObject BlurBG; // Greyout object in canvas
	public Text Profile_Name;
	public Text Profile_Text;
	Text CoinNoText;
	GameObject LS1;
	GameObject LS2;
	GameObject LS3;
	// Use this for initialization
	void Start () {
		PauseUI = this.gameObject;
		CoinNoText = PauseUI.transform.GetChild(5).transform.GetChild(1).GetComponent<Text>();
		LS1 = PauseUI.transform.GetChild(6).transform.GetChild(3).gameObject;
		LS2 = PauseUI.transform.GetChild(6).transform.GetChild(4).gameObject;
		LS3 = PauseUI.transform.GetChild(6).transform.GetChild(5).gameObject;

		//Profile Name Capturing
		Profile_Name.text = Environment.MachineName;
		Profile_Text.text = Environment.MachineName.Substring(0,1);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(isPaused){
				Resume();
			} else {
				Pause();
			}
		}
		
	}

	public void Resume(){
		PauseUI.transform.localScale = new Vector3(0,0,1);
		
		GameObject.FindWithTag("Player").GetComponent<Hmovement>().enabled = true;
		
		for(int i=0; i<GameObject.FindGameObjectsWithTag("enemy").Length; i++){
			GameObject.FindGameObjectsWithTag("enemy")[i].GetComponent<Emovement>().enabled = true;
		}
		// //Senemey
		// for(int i=0; i<GameObject.FindGameObjectsWithTag("senemy").Length; i++){
		// 	GameObject.FindGameObjectsWithTag("senemy")[i].GetComponent<SEmovement>().enabled = true;
		// }
		// //GreenMonster
		// for(int i=0; i<GameObject.FindGameObjectsWithTag("GreenMonster").Length; i++){
		// 	GameObject.FindGameObjectsWithTag("GreenMonster")[i].GetComponent<GreenMovement>().enabled = true;
		// }
		BlurBG.SetActive(false);
		Time.timeScale = 1F;
		isPaused = false;
	}

	void Pause(){
		PauseUI.transform.localScale = new Vector3(1,1,1);
		
		GameObject.FindWithTag("Player").GetComponent<Hmovement>().enabled = false;
		
		for(int i=0; i<GameObject.FindGameObjectsWithTag("enemy").Length; i++){
			GameObject.FindGameObjectsWithTag("enemy")[i].GetComponent<Emovement>().enabled = false;
		}
		// //Senemey
		// for(int i=0; i<GameObject.FindGameObjectsWithTag("senemy").Length; i++){
		// 	GameObject.FindGameObjectsWithTag("senemy")[i].GetComponent<SEmovement>().enabled = false;
		// }
		// //GreenMonster
		// for(int i=0; i<GameObject.FindGameObjectsWithTag("GreenMonster").Length; i++){
		// 	GameObject.FindGameObjectsWithTag("GreenMonster")[i].GetComponent<GreenMovement>().enabled = false;
		// }
		
		
		BlurBG.SetActive(true);
		Time.timeScale = 0F;
		isPaused = true;
		
		//Coin Status
		CoinNoText.text = Hmovement.coinCount.ToString();

		//Health Status
		if(HealthBar.health >=1 && HealthBar.health<=30){
			LS2.SetActive(false);
			LS3.SetActive(false);
		}
				
		
		else if(HealthBar.health>=31 && HealthBar.health<=99){
				LS3.SetActive(false);
			}
				
		else if(HealthBar.health==100){
				LS1.SetActive(true);
				LS2.SetActive(true);
				LS3.SetActive(true);
			}
	}
}
