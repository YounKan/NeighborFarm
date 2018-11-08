using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyItem : MonoBehaviour {

	void OnMouseDown (){
		
		for (int i = 0; i < TreeModel.AllTrees.Count; i++) {
			if (this.gameObject.name == TreeModel.AllTrees [i].Name) {
				if (userDetail.money >= TreeModel.AllTrees [i].BuyCost) {
					BuyItem (i);
					userDetail.money -= TreeModel.AllTrees [i].BuyCost;
					print (userDetail.Baglist.Count);
					break;
				}
			}
		}
	}

	public void BuyItem(int index ){
		bool check = false;

		for (int i = 0; i < userDetail.Baglist.Count; i++) {
			if (userDetail.Baglist [i].nameItem == TreeModel.AllTrees [index].Name) {
				userDetail.Baglist [i].amount += TreeModel.AllTrees [index].Amount;
				check = true;
			}
		}
	
		if(!check){
			BagDetail item = new BagDetail ();
			item.nameItem = TreeModel.AllTrees [index].Name;
			item.ItemID = TreeModel.AllTrees [index].ID;
			item.amount =TreeModel.AllTrees [index].Amount;
			userDetail.Baglist.Add (item);
		}

	}

}
