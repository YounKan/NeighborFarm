using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapScene : MonoBehaviour,IPointerExitHandler {

	void OnMouseDown ()
	{
		if (this.gameObject.name=="shop") {
			SceneManager.UnloadScene ("Map");
			GlobalObj.Instance.Sencestatus = "Shop";
			SceneManager.LoadScene ("Shop",LoadSceneMode.Additive);
			GlobalObj.Instance.map.SetActive (true);
		}else if (this.gameObject.name=="home") {
			SceneManager.UnloadScene ("Map");
			GlobalObj.Instance.Sencestatus = "home";
			SceneManager.LoadScene ("home",LoadSceneMode.Additive);
			GlobalObj.Instance.map.SetActive (true);
		}else if (this.gameObject.name=="farm") {
			SceneManager.UnloadScene ("Map");
			GlobalObj.Instance.Sencestatus = "Farming";
			GlobalObj.Instance.ResumeGame ();
			GlobalObj.Instance.map.SetActive (true);
		}
	}

	public void OnPointerExit(PointerEventData eventData){
		EventSystem.current.SetSelectedGameObject (null);
	}

}
		
		

