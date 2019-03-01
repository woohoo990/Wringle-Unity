using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMapper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Load_MainMenu(){
		SceneManager.LoadScene("Main Menu");
	}

	public void Load_Map(){
		SceneManager.LoadScene("LevelMap");
	}

	public void Load_Level1(){
		SceneManager.LoadScene("Level_1");
	}

	public void Load_Level2(){

	}
	public void Load_Level3(){

	}
	public void Load_Level4(){

	}
	public void Load_Level5(){

	}

}
