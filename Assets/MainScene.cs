using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour,IPointerExitHandler {
	public InputField user;
	public Button btnStart;
	public static string username;

	void Start ()
	{

		btnStart.onClick.AddListener (Play);
	}
		
	public void OnPointerExit(PointerEventData eventData){
		EventSystem.current.SetSelectedGameObject (null);
	}

	public void Play(){
		userDetail.Userame = user.text;
		userDetail.money = 1000;
		userDetail.day = 1;
		userDetail.energy = 100;
		SceneManager.LoadScene ("Farming");

	}
}
