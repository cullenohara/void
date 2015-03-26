using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTile : MonoBehaviour {

	public bool inUse = false;
	public bool canUse = false;
	public Vector3 tileId;

	public Renderer rend;
	public Color tileColor;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		tileColor = rend.material.color;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			inUse = true;
			print (transform.position);
		}
		else if(col.gameObject.tag == "bomb")
		{
			inUse = true;
		}
	}

	void OnCollisionExit (Collision col)
	{
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "bomb")
		{
			inUse = false;
		}
	}

	void OnMouseEnter ()
	{
		if(inUse == true || canUse == false)
		{
			rend.material.color = Color.red;
		}
		else
		{
			rend.material.color = Color.green;
		}
	}

	void OnMouseExit ()
	{
		rend.material.color = tileColor;
	}
}
