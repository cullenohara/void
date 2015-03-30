using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Weapons {

	public int count;
	public int power;
	public string weapname;
	public string desc;
	public Texture icon;
	public Sprite image;
	public Vector3 parent;
	public WeaponType type;

	public Weapons (int _count, int _power, string _name, string _desc, Texture _icon, Sprite _image, WeaponType _type, Vector3 _parent)
	{
		count = _count;
		power = _power;
		weapname = _name;
		desc = _desc;
		icon = _icon;
		image = _image;
		type = _type;
		parent = _parent;
	}

	public enum WeaponType
	{
		ice,
		fire,
		poison
	}

}
