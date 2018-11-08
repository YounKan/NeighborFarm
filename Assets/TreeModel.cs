using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeModel {
	
	public int ID { get; private set; }
	public string Name { get; private set; }
	public int Cost { get; private set; }
	public int Growth { get; private set; }
	public int Amount { get; private set; }
	public int Season { get; private set; }
	public int ExtraCost { get; private set; }
	public int BuyCost { get; private set; }

	public TreeModel Clone() {
		return (TreeModel)this.MemberwiseClone ();
	}

	public static List<TreeModel> AllTrees = 
		new List<TreeModel>() {
		new TreeModel(){ID=0,Name="Bean", BuyCost=200,Cost=60,Growth=10,Season=2,ExtraCost=80, Amount=9}, 
		new TreeModel(){ID=1,Name="Brassica", BuyCost=500,Cost=250,Growth=15,Season=2,ExtraCost=300, Amount=9},
		new TreeModel(){ID=2,Name="Strawberry", BuyCost=150,Cost=30,Growth=5,Season=2,ExtraCost=45, Amount=9},
		new TreeModel(){ID=3,Name="Tomato", BuyCost=200,Cost=60,Growth=10,Season=0,ExtraCost=120, Amount=9},
		new TreeModel(){ID=4,Name="Corn", BuyCost=300,Cost=100,Growth=12,Season=0,ExtraCost=180, Amount=9},
		new TreeModel(){ID=5,Name="Pumpkin", BuyCost=500,Cost=250,Growth=15,Season=0,ExtraCost=300, Amount=9},
		new TreeModel(){ID=6,Name="Carrot", BuyCost=300,Cost=120,Growth=8,Season=1,ExtraCost=180, Amount=9},
		new TreeModel(){ID=7,Name="Rice", BuyCost=120,Cost=80,Growth=10,Season=1,ExtraCost=200, Amount=9},
		new TreeModel(){ID=8,Name="Sweet Papper", BuyCost=300,Cost=120,Growth=6,Season=1,ExtraCost=180, Amount=9},
		new TreeModel(){ID=9,Name="Vitamin", BuyCost=100,Amount=6},
		new TreeModel(){ID=10,Name="Insect Killer", BuyCost=80, Amount=9},
		new TreeModel(){ID=11,Name="Food", BuyCost=50,Growth=20, Amount=1}

	};
}
