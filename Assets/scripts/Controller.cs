using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	private List<GameObject> tiles = new List<GameObject>();
	public GameObject startTile;

	// Use this for initialization
	void Start () {

		foreach (GameObject tile in GameObject.FindGameObjectsWithTag("tile"))
		{
			tiles.Add(tile);
			if(tile.transform.position == new Vector3(0,0,0))
			{
				startTile = tile;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GetAxis();

	}

	void GetAxis ()
	{
		if(Input.GetAxisRaw("X axis")> 0.3)
		{

		}
		if(Input.GetAxisRaw("X axis") < -0.3)
		{

		}
	}
}
