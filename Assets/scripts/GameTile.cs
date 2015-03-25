using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTile : MonoBehaviour {

	public int tileId;
	public GameObject bombPrefab;
	public GameObject player;
	public bool inUse = false;
	public bool canUse = false;

	public Renderer rend;
	public Color tileColor;

	void Start ()
	{
		bombPrefab = GameObject.FindGameObjectWithTag( "bomb" );
		player = GameObject.FindGameObjectWithTag( "Player" );
		rend = GetComponent<Renderer>();
		tileColor = rend.material.color;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			inUse = true;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().BroadcastMessage("GetPosition", transform.position);
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
