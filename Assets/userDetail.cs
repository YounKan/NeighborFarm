using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class userDetail : MonoBehaviour  {

	public static string Userame { get; set;}
	public static int energy { get; set;}
	public static int money { get; set;}
	public static List<BagDetail> Baglist = new List<BagDetail>();
	public static List<PlantDetail> list = new List<PlantDetail>();

	private static float timer;
	public static int day{ get; set;}
	public static int minute;
	public static int sec;
	public  static int seasonId{ get; set;}
	public string[] season = new string[] {"Summer","Rainy","Winter"};

	public Text showTime;
	public Text showUser;
	public Text showenergy;
	public Text showMoney;




	void Update () {
		if (minute == 1) {
			if (day == 30) {
				if (seasonId == 0) {
					seasonId += 1;
				}else if (seasonId == 1) {
					seasonId += 1;
				}else if (seasonId == 2) {
					seasonId = 1;
				}
				day = 0;
			
			}
				day += 1;
				timer = 0;
				energy = 100;

			GlobalObj.Instance.findInsect ();
			GlobalObj.Instance.findGamgObj ();
		}

		timer += Time.deltaTime;
		minute =  (int)(timer / 60);
		sec = (int)(timer % 60);
		showTime.text = String.Format ("day : "+day+"   "+season[seasonId]+"   "+"{00:00}:{01:00}", minute, sec);
		showUser.text = Userame;
		showenergy.text = energy.ToString();
		showMoney.text = money.ToString();
	}
}


