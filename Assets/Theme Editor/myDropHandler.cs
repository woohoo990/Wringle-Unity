using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class myDropHandler : MonoBehaviour, IDropHandler {
	public static Vector3 itemEndDragPosition;
	public Text mText = null;
	public void OnDrop (PointerEventData eventData)
	{
		myDragHandler.itemBeingDragged.transform.SetParent(transform);
		itemEndDragPosition = myDragHandler.itemBeingDragged.transform.localPosition;
		// updateStatus();
		// Instantiate(myDragHandler.itemBeingDragged.gameObject,
		// 			new Vector3(Input.mousePosition.x, Input.mousePosition.x, 1000),
		// 			Quaternion.identity);

	}

	private void updateStatus(){
		int count = transform.childCount;
		string res = " ";
		for(int i = 0; i < count; i++){
			res += gameObject.transform.GetChild(i).gameObject.name.Split('I')[0] + " ";
		}
		// Debug.Log(res);
		mText.text = res;
	}


	// Use this for initialization
	void Start () {
		// mText.text="";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}