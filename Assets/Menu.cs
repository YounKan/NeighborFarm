using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour ,IPointerExitHandler
{
	public GameObject axe, bucket, harvest, Seed;
	public List<GameObject> Seedlist = new List<GameObject> ();

	float[] arrX = new float[] {-5.83f,-5.83f,-5.83f,-5.83f,-6.83f,-6.83f,-6.83f,-6.83f};
	float[] arrY = new float[] {-2.623f,-1.313f,0.003f,1.313f,-2.623f,-1.313f,0.003f,1.313f};


	void OnMouseDown ()
	{
		if (this.gameObject.name == "bag") {
			if (!Seed.activeInHierarchy && userDetail.Baglist.Count != 0) {
				Seed.SetActive (true);

				//high = 1.31 width = 1
			
				for (int k = 0; k < userDetail.Baglist.Count; k++) {
					for (int i = 0; i < Seedlist.Count; i++) {
						if (userDetail.Baglist [k].nameItem == Seedlist [i].gameObject.name) {
							Seedlist [i].gameObject.SetActive (true);
							Seedlist [i].gameObject.transform.position = new Vector3 (arrX [k], arrY[k]);
							break;
						}
					}
				}					

				axe.SetActive (false);
				bucket.SetActive (false);
				harvest.SetActive (false);
			
			} else {
				Seed.SetActive (false);
				int index = 0;
				for (int i = 0; i < Seedlist.Count; i++) {
					if (userDetail.Baglist [index].nameItem == Seedlist [i].gameObject.name) {
						Seedlist [i].gameObject.SetActive (false);
						index += 1;
					}
				}
			}

		} else if (this.gameObject.name == "map") {
			if (GlobalObj.Instance.Sencestatus == "Shop") {
				SceneManager.UnloadScene ("Shop");
				SceneManager.LoadScene ("Map", LoadSceneMode.Additive);
			} else if (GlobalObj.Instance.Sencestatus == "home") {
				SceneManager.UnloadScene ("home");
				SceneManager.LoadScene ("Map", LoadSceneMode.Additive);
			} else if (GlobalObj.Instance.Sencestatus == "Farming") {
				SceneManager.LoadScene ("Map", LoadSceneMode.Additive);
				GlobalObj.Instance.pausedGame ();
				GlobalObj.Instance.map.SetActive (false);
			}

		} else if (this.gameObject.name == "tool") {
			if (!axe.activeInHierarchy) {
				axe.SetActive (true);
				bucket.SetActive (true);
				harvest.SetActive (true);

				Seed.SetActive (false);

			} else {
				axe.SetActive (false);
				bucket.SetActive (false);
				harvest.SetActive (false);
			}
		}
	}


	public void OnPointerExit (PointerEventData eventData)
	{
		EventSystem.current.SetSelectedGameObject (null);
	}
}
	