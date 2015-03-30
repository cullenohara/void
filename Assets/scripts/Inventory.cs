using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Weapons> inventory = new List<Weapons>();
	public WeaponList database;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag("WeaponList").GetComponent<WeaponList>();
		inventory.Add(database.weaponList[0]);
		inventory.Add(database.weaponList[1]);
	}
	
	void OnGUI ()
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			GUI.DrawTexture(new Rect(10, i * 60, 48, 48), inventory[i].icon);
		}
	}
}
