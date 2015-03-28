using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTile : MonoBehaviour {

	public bool inUse = false;
	public bool canUse = false;
	public Vector3 tileId;

	public Renderer rend;
	public Color tileColor;

	private GameObject player;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		tileColor = rend.material.color;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			inUse = true;
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
		if(player.GetComponent<Player>().canAttack == true)
		{
			if(inUse == true)
			{
				rend.material.color = Color.red;
			}
			else
			{
				rend.material.color = Color.cyan;
			}
		}

		if(player.GetComponent<Player>().canMove == true)
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
	}

	void OnMouseExit ()
	{
		rend.material.color = tileColor;
	}
}
