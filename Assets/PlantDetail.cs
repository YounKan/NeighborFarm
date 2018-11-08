using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantDetail {
	public string Name;
	public string type;
	public int IDtype;
	public int index;
	public bool isBlank = true;
	public bool statusWater;
	public bool statusVitamin;
	public bool statusInsectKiller;
 	public int startDay;
	public int endDay;
	public int growth =0;
}
