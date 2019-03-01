using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class uibuttonaction : MonoBehaviour,IPointerClickHandler {
	
	public void OnPointerClick(PointerEventData pointer){
		if(gameObject == GameObject.Find("Restart_btn"))
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		if(gameObject == GameObject.Find("Exit_btn"))
		SceneManager.LoadScene(0);

		if(gameObject == GameObject.Find("Next_btn"))
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
}
