using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{

	private Vector3 delta;
	private Vector3 old;
	public Sprite bucket;
	public Sprite buckets;
	public Sprite soil;
	public int waterBuckets ;



	void OnMouseDown ()
	{
		delta = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		old = transform.position;
		if (this.gameObject.name == "Food") {
			if (SetBagDetail (this.gameObject.name)) {
				userDetail.energy += 30;
			} 
		}
	}

	void OnMouseDrag ()
	{
		Vector3 v = Camera.main.ScreenToWorldPoint (Input.mousePosition) - delta;
		transform.position = new Vector3 (v.x, v.y);

	}
	void OnMouseUp (){
		transform.position = old;
	}



	void OnTriggerEnter2D (Collider2D other){

		if (userDetail.energy >= 3) {
			if (this.gameObject.name == "axe") {
				if (other.name.Substring (0, 7) == "nothing") {
					other.GetComponent<SpriteRenderer> ().sprite = soil;
					other.name = setPlant (other.name);
					other.tag = "plant";
					userDetail.energy -= 3;
				}
			}

			if (this.gameObject.name == "harvest") {
				var plantlist = GlobalObj.list;
				int index = 999;
				for (int i = 0; i < plantlist.Count; i++) {
					if (plantlist [i].Name == other.name) {
						index = i;
						break;
					}
				}
				if (index != 999) {
					if (TreeModel.AllTrees [plantlist [index].IDtype].Growth == plantlist [index].growth) {
						other.GetComponent<SpriteRenderer> ().sprite = null;
						other.name = setMoney (other.name);
						other.tag = "Untagged";
						userDetail.energy -= 3;
					}
				}
			}


			if (this.gameObject.name == "bucket") {
				if (other.name == "reservoir") {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = buckets;
					this.gameObject.name = "buckets";
					waterBuckets = 3;
				}
			}
			if (this.gameObject.name == "buckets") {
				if (other.name.Substring (0, 5) != "plant" && other.name.Substring (0, 7) != "nothing") {
					if (setPlantWater (other.name)) {
						other.GetComponent<SpriteRenderer> ().color = Color.gray;
						userDetail.energy -= 3;
				
					}
					if (waterBuckets == 0) {
						this.gameObject.GetComponent<SpriteRenderer> ().sprite = bucket;
						this.gameObject.name = "bucket";

					}
					
				}
			}
		}
		if (this.gameObject.name == "Bean") {
			if (other.name.Substring (0, 5) == "plant") {
				if (SetBagDetail (this.gameObject.name)) {
					other.name = SetPlantDetail (other.name, 0);
					other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [0].Name, 0);
				} 
			}
		}
			if (this.gameObject.name == "Brassica") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 1);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [1].Name, 0);
					} 
				}
			}
			if (this.gameObject.name == "Strawberry") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 2);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [2].Name, 0);
					} 
				}
			}
			if (this.gameObject.name == "Tomato") {
				if (other.name.Substring (0, 5) == "plant") {
					other.name = SetPlantDetail (other.name, 3);
					SetBagDetail (this.gameObject.name);
					other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [3].Name, 0);
				}
			}

			if (this.gameObject.name == "Corn") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 4);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [4].Name, 0);
					} 
				}
			}

			if (this.gameObject.name == "Pumpkin") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 5);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [5].Name, 0);
					} 
				}
			}

			if (this.gameObject.name == "Carrot") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 6);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [6].Name, 0);
					} 
				}
			}

			if (this.gameObject.name == "Rice") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 7);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [7].Name, 0);
					} 
				}
			}

			if (this.gameObject.name == "Sweet Papper") {
				if (other.name.Substring (0, 5) == "plant") {
					if (SetBagDetail (this.gameObject.name)) {
						other.name = SetPlantDetail (other.name, 8);
						other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (TreeModel.AllTrees [8].Name, 0);
					} 
				}
			}

			if (this.gameObject.name == "Vitamin") {
				if (other.name.Substring (0, 5) != "plant" && other.name.Substring (0, 7) != "nothing") {
					if (setVitamin (other.name)) {
						if (SetBagDetail (this.gameObject.name)) {
						print (other.name);
						other.GetComponent<SpriteRenderer> ().color = Color.red;
						}
					} 
				}
			}

		if (this.gameObject.name == "Insect Killer") {
			int index = setInsectKiller (other.name);
			if (index !=999 && SetBagDetail (this.gameObject.name)) {
				var plantlist = GlobalObj.list;
				other.GetComponent<SpriteRenderer> ().sprite = GlobalObj.Instance.FindTree (plantlist [index].type, plantlist [index].growth);
				other.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				}
			} 
		}
		




	
	public bool SetBagDetail(string thisname ){
	for (int i = 0; i < userDetail.Baglist.Count; i++) {
			if (userDetail.Baglist [i].nameItem == thisname) {
				if (userDetail.Baglist [i].amount > 1) {
					userDetail.Baglist [i].amount -= 1;
					return true;
				} else if(userDetail.Baglist [i].amount == 1) {
				
					userDetail.Baglist.RemoveAt (i);
					this.gameObject.SetActive (false);
					return true;
				}
				
			}
		}
		return false;
	}

	public string SetPlantDetail(string othername ,int seed){
		var plantlist = GlobalObj.list;
		for (int i = 0; i < plantlist.Count; i++) {
			if (plantlist [i].Name == othername) {
				plantlist [i].Name = TreeModel.AllTrees [seed].Name+i;
				plantlist [i].startDay = userDetail.day;
				plantlist[i].endDay = plantlist [i].startDay +TreeModel.AllTrees [seed].Growth;
				plantlist [i].type = TreeModel.AllTrees [seed].Name;
				plantlist [i].statusWater = false;
				plantlist [i].statusVitamin = false;
				plantlist [i].isBlank = false;
				plantlist [i].statusInsectKiller = false;
				plantlist[i].IDtype=TreeModel.AllTrees [seed].ID;
				return plantlist [i].Name;
			}
		}
		return null;
	}


	public string setPlant(string othername ){
		var plantlist = GlobalObj.list;
		for (int i = 0; i < plantlist.Count; i++) {
			if (plantlist [i].Name == othername) {
				plantlist [i].Name = "plant" + i;
				return plantlist [i].Name;
			}
		}
		return null;
	}



	public bool setPlantWater(string othername ){
		var plantlist = GlobalObj.list;
		for (int i = 0; i < plantlist.Count; i++) {
			if (plantlist [i].Name == othername) {
				if (!plantlist [i].statusWater) {
					plantlist [i].statusWater = true;
					waterBuckets -= 1;
					return true;
				}
			}

		}
		return false;
	}

	public bool setVitamin(string othername ){
		var plantlist = GlobalObj.list;
		for (int i = 0; i < plantlist.Count; i++) {
			if (plantlist [i].Name == othername) {
				if (!plantlist [i].statusVitamin) {
					plantlist [i].growth += 1;
					plantlist [i].statusVitamin = true;
					return true;
				}
			}

		}
		return false;

	}

	public int setInsectKiller(string othername ){
		var plantlist = GlobalObj.list;
		for (int i = 0; i < plantlist.Count; i++) {
			if (plantlist [i].Name == othername) {
				if (plantlist [i].statusInsectKiller && !plantlist [i].isBlank) {
					plantlist [i].statusInsectKiller = false;
					return i;
				}
			}

		}
		return 999;

	}

	public string setMoney(string othername ){
		var plantlist = GlobalObj.list;
		for (int i = 0; i < plantlist.Count; i++) {
			if (plantlist [i].Name == othername) {
				if (userDetail.seasonId == TreeModel.AllTrees [plantlist [i].IDtype].Season) {
					userDetail.money += TreeModel.AllTrees [plantlist [i].IDtype].ExtraCost;
				} else {
					userDetail.money += TreeModel.AllTrees [plantlist [i].IDtype].Cost;
				}
				plantlist [i].Name ="nothing" + i;
				plantlist [i].startDay = 0;
				plantlist[i].endDay =0;
				plantlist [i].type = null;
				plantlist [i].statusWater = false;
				plantlist [i].isBlank = true;
				plantlist [i].statusInsectKiller = false;
				plantlist [i].statusVitamin = false;
				plantlist[i].IDtype=0;
				plantlist[i].growth=0;
				return plantlist [i].Name;
			}

		}
		return "";
	}
		
}
	
