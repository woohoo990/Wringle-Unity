using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackme : MonoBehaviour {
	GameObject pointStart;
	GameObject pointEnd;
	GameObject pointEnd2;
	float distance;
	float distanceCovered;
	float percentage;
	public Image PlayerTrack;
	public Image GoalTrack;
	public Transform Diamond;
	private bool enableMap = false;
	float TempPosX;
	float TempPosY;

	// Use this for initialization
	void Start () {
		pointStart = GameObject.Find("PointStart");
		pointEnd = GameObject.Find("PointEnd");
		pointEnd2 = GameObject.Find("PointEnd (1)");

		TempPosX = PlayerTrack.transform.localPosition.x;
		TempPosY = PlayerTrack.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		// distance = pointEnd.transform.position.x - pointStart.transform.position.x;
		// distanceCovered = transform.position.x - pointStart.transform.position.x;
		// percentage = (distanceCovered/distance)*100;

		// if(percentage>=0 && percentage<=100){
		// 	slider.value = percentage;
			
		// }
		// print(pointEnd.transform.position - transform.position);	

		// PlayerTrack.transform.localPosition = new Vector3((transform.position.x-pointStart.transform.position.x), 
		// PlayerTrack.transform.localPosition.y, PlayerTrack.transform.localPosition.z);
		
		//Player Track
		float TempV1x  = 0-(PlayerTrack.transform.parent.GetComponent<Image>().rectTransform.sizeDelta.x/2)+
		(PlayerTrack.rectTransform.sizeDelta.x/2);
		float TempV1y  = 0-(PlayerTrack.transform.parent.GetComponent<Image>().rectTransform.sizeDelta.y/2)+
		(PlayerTrack.rectTransform.sizeDelta.y/2);
		float TempV2 = 0+(PlayerTrack.transform.parent.GetComponent<Image>().rectTransform.sizeDelta.x/2)-
		(PlayerTrack.rectTransform.sizeDelta.x/2);
		float TempV3 = 0+(PlayerTrack.transform.parent.GetComponent<Image>().rectTransform.sizeDelta.y/2)-
		(PlayerTrack.rectTransform.sizeDelta.y/2);
		float TempDistancex = TempV2 - TempV1x;
		float TempDistanceCoveredx = TempPosX - TempV1x;
		float TempPercentx = (TempDistanceCoveredx/TempDistancex)*100;

		float TempDistancey = TempV3 - TempV1y;
		float TempDistanceCoveredy = TempPosY - TempV1y;
		float TempPercenty = (TempDistanceCoveredy/TempDistancey)*100;
		

		//Point Track
		float distancex = pointEnd.transform.position.x - pointStart.transform.position.x;
		float PosX = transform.position.x;
		float distanceCoveredx = PosX - pointStart.transform.position.x;
		float Percentx = (distanceCoveredx/distancex)*100;

		float distancey = pointEnd2.transform.position.y - pointStart.transform.position.y;
		float PosY = transform.position.y;
		float distanceCoveredy = PosY - pointStart.transform.position.y;
		float Percenty = (distanceCoveredy/distancey)*100;

		//Goal Track
		float distanceDiamondCoveredx = Diamond.position.x - pointStart.transform.position.x;
		float PercentDiamondx = (distanceDiamondCoveredx/distancex)*100;

		float distanceDiamondCoveredy = Diamond.position.y - pointStart.transform.position.y;
		float PercentDiamondy = (distanceDiamondCoveredy/distancey)*100;
		
		float GoalAvgX = (TempDistancex*PercentDiamondx)/100;
		float GoalAvgY = (TempDistancey*PercentDiamondy)/100;
		GoalTrack.transform.localPosition = new Vector2(GoalAvgX+TempV1x,GoalAvgY+TempV1y);

		//
		TempPosX = (TempDistancex*Percentx)/100 + TempV1x;
		TempPosY = (TempDistancey*Percenty)/100 + TempV1y;

		if((TempPercentx>=0 && TempPercentx<=100) && (TempPercenty>=0 && TempPercenty<=100)){
			
			PlayerTrack.transform.localPosition = new Vector2(TempPosX,TempPosY);
		}

		if(Input.GetKeyDown(KeyCode.M) && !enableMap){
			show_MapTracker();
			enableMap = true;
		}
		else if(Input.GetKeyDown(KeyCode.M) && enableMap){
			hide_MapTracker();
			enableMap = false;
		}


	}

	void show_MapTracker(){
		PlayerTrack.transform.parent.gameObject.SetActive(true);
	}

	void hide_MapTracker(){
		PlayerTrack.transform.parent.gameObject.SetActive(false);
	}
}
