using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompleteGoal : MonoBehaviour {
	public int CollectionNumber;
	public GameObject EndGoal;
	public Slider objective;
	public Text foreGroundText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		objective.value = ((float)Hmovement.coinCount/(float)CollectionNumber)*100;
		foreGroundText.text = Hmovement.coinCount +"/"+CollectionNumber;
		if(Hmovement.coinCount == CollectionNumber){
			EndGoal.SetActive(true);
		}
	}
}
