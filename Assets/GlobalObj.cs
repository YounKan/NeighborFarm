using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class GlobalObj : MonoBehaviour
{

	public static GlobalObj Instance;

	void Awake ()
	{
		Instance = this;

	}

	public  NamedImage[] TreeImages;
	public  GameObject plant;
	public  String Sencestatus;
	public static List<PlantDetail> list = new List<PlantDetail> ();

	public GameObject map;

	GameObject[] plantArr;
	GameObject[] FarmingArr;



	public  Sprite FindTree (string treeName, int index)
	{
		foreach (NamedImage obj in TreeImages) {
			if (obj.Name == treeName)
				return obj.Image [index];
		}
			
		Debug.Assert (false);
		return null;
	}


	void Start ()
	{
		int num = 0;
		//high = 0.872 width = 1.144
		float xPlant = -4.3f;
		float yPlant = 0.3f;
		for (int y = 0; y < 4; y++) {
			for (int x = 0; x < 6; x++) {
				var Plant =	Instantiate (plant, new Vector3 (xPlant, yPlant, 0), Quaternion.identity);
				Plant.name = "nothing" + num.ToString ();
				PlantDetail plantdetail = new PlantDetail ();
				plantdetail.Name = Plant.name;
				plantdetail.index = num;
				list.Add (plantdetail);
				xPlant += 1.3f;
				num += 1;
			}
			xPlant = -4.3f;
			yPlant -= 1f;

		}
		Sencestatus = "Farming";
			
	}

	public void pausedGame ()
	{
		plantArr = GameObject.FindGameObjectsWithTag ("plant");
		FarmingArr = GameObject.FindGameObjectsWithTag ("Farming");
		foreach (GameObject g in plantArr) {
			g.SetActive (false);
		}
		foreach (GameObject g in FarmingArr) {
			g.SetActive (false);
		}
	
	}

	public void ResumeGame ()
	{
		foreach (GameObject g in plantArr) {
			g.SetActive (true);
		}
		foreach (GameObject g in FarmingArr) {
			g.SetActive (true);
		}

	}

	public  void findGamgObj ()
	{
		GameObject[] plant;
		plant = GameObject.FindGameObjectsWithTag ("plant");

		if (plant != null) {
			for (int i = 0; i < plant.Length; i++) {
				for (int k = 0; k < list.Count; k++) {
					if (plant [i].name == list [k].Name) {
						if (list [k].statusWater && list [k].growth < TreeModel.AllTrees [list [k].IDtype].Growth) {

							if (!list [k].statusInsectKiller ){
								plant [i].GetComponent<SpriteRenderer> ().sprite = FindTree (list [k].type, list [k].growth);
								list [k].growth += 1;
								print (list [k].Name + "findGamgObj" + list [k].growth);
							}
							

						}
						plant [i].GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
						list [k].statusWater = false;
					}
					
				}
			}
		}
	}

	public  void findInsect ()
	{
		GameObject[] plant;
		plant = GameObject.FindGameObjectsWithTag ("plant");
		if (plant != null) {
			for (int i = 0; i < plant.Length; i++) {
				for (int k = 0; k < list.Count; k++) {
					if (plant [i].name == list [k].Name && !list [k].isBlank && UnityEngine.Random.Range (1, 10) == 1) {
							list [k].statusInsectKiller = true;
	
							if (list [k].statusInsectKiller && list [k].growth <= TreeModel.AllTrees [list [k].IDtype].Growth / 2) {
								plant [i].GetComponent<SpriteRenderer> ().sprite = FindTree (list [k].type, TreeModel.AllTrees [list [k].IDtype].Growth);
								plant [i].GetComponent<SpriteRenderer> ().sortingOrder = 2;
								print (list [k].Name + "findInsect 1" + list [k].growth);
							} else if (list [k].statusInsectKiller && list [k].growth >= TreeModel.AllTrees [list [k].IDtype].Growth / 2) {
								plant [i].GetComponent<SpriteRenderer> ().sprite = FindTree (list [k].type, TreeModel.AllTrees [list [k].IDtype].Growth+1);
								plant [i].GetComponent<SpriteRenderer> ().sortingOrder = 2;
								print (list [k].Name + "findInsect 2" + list [k].growth);
							}
						}
					}

				}

		}

	}
}

[Serializable]
public struct NamedImage
{
	public string Name;
	public Sprite[] Image;
}

