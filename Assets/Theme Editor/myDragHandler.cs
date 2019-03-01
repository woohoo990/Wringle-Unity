using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class myDragHandler : MonoBehaviour, IBeginDragHandler ,IDragHandler, IEndDragHandler
{
    
    // public static GameObject itemBeingDragged; 
    Vector3 startPosition;
    Transform startParent;
    int startSiblingIndex;
	// Transform returnToParent = null;
    public Transform parentPanel;
    public GameObject toDragObject;
    private Image toDrag;
    private Transform WindowPanel;
    private GameObject WindowObject;
    public static Image itemBeingDragged;
    public Transform ItemContent;
    private Transform canvas;
    


    public void OnBeginDrag(PointerEventData eventData)
    {   startPosition = transform.localPosition;
        startParent = transform.parent;
        startSiblingIndex = transform.GetSiblingIndex();
        itemBeingDragged =  Instantiate(toDrag, startPosition, Quaternion.identity) as Image;
        itemBeingDragged.transform.SetParent(canvas);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //-----------------------------------------------------------//
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetSiblingIndex(1000);
        itemBeingDragged.transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // itemBeingDragged = null;
        transform.SetParent(startParent);
        transform.SetSiblingIndex(startSiblingIndex);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // itemBeingDragged.transform.SetParent();
        if(eventData.pointerEnter != WindowObject){
            Destroy(itemBeingDragged.gameObject);
        }
        transform.localPosition = startPosition;

    }


    // Use this for initialization
    void Start()
    {
        // toDrag = GameObject.Find("TestObject").GetComponent<Image>();
        toDrag = toDragObject.GetComponent<Image>();
        WindowPanel = GameObject.Find("WindowPanel").transform;
        WindowObject = GameObject.Find("WindowPanel");
        canvas = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
