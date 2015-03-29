using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour {

	private GameObject getWeapons;
	private TextMesh countText;

	public string WeaponName;
	public string WeaponDesc;
	public int WeaponPower;
	public int TurnCount;
	public Sprite WeaponSprite;
	public Vector3 ParentTile;

	private Player playerScript;

	void Start ()
	{
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void SetWeaponType (int id)
	{
		getWeapons = GameObject.FindGameObjectWithTag("WeaponList");
		WeaponName = getWeapons.GetComponent<WeaponList>().weaponList[id].weapname;
		WeaponDesc = getWeapons.GetComponent<WeaponList>().weaponList[id].desc;
		WeaponPower = getWeapons.GetComponent<WeaponList>().weaponList[id].power;
		TurnCount = getWeapons.GetComponent<WeaponList>().weaponList[id].count;
		WeaponSprite = getWeapons.GetComponent<WeaponList>().weaponList[id].image;
		//set the turn count on this weapon
		countText = transform.GetChild(0).GetComponent<TextMesh>();
		countText.text = TurnCount.ToString();
	}

	void SetCount ()
	{
		TurnCount--;
		if(TurnCount == 0)
		{
			Destroy(gameObject);
			foreach (GameObject tile in playerScript.tiles)
			{
				if(tile.GetComponent<GameTile>().tileId == ParentTile)
				{
					tile.GetComponent<GameTile>().inUse = false;
				}
			}
		}
		countText.text = TurnCount.ToString();
	}
}
