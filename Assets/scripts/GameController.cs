using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<GameObject> tiles = new List<GameObject>();

	public GameObject player;
	public GameObject ai;
	public GameObject bomb;

	public float player_x;
	public float player_z;

	public Vector3 clickPos;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		bomb = GameObject.FindGameObjectWithTag("bomb");

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("tile"))
		{
			tiles.Add(go);
		}
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "tile" && hit.transform.gameObject.GetComponent<GameTile>().inUse == false && hit.transform.gameObject.GetComponent<GameTile>().canUse == true)
				{
					clickPos = hit.transform.position;
					//bomb.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
				}
			}
		}

		player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(clickPos.x, player.transform.position.y, clickPos.z), Time.deltaTime * 3);
		CheckTiles();
	}

	//Gets the current X / Z position of the tile the player currently occupies
	void GetPosition (Vector3 playerPosition)
	{
		player_x = playerPosition.x;
		player_z = playerPosition.z;
	}

	//Checks every tile in the scene to see which tiles the player can move to
	//Players can only move one space at a time
	//Players cannot move diagonally
	void CheckTiles ()
	{
		foreach(GameObject tile in tiles)
		{
			//More than one space away
			if(Mathf.Abs(tile.transform.position.x) > Mathf.Abs(player_x) + 1 || Mathf.Abs(tile.transform.position.z) > Mathf.Abs(player_z) + 1 || 
			   Mathf.Abs(tile.transform.position.x) < Mathf.Abs(player_x) - 1 || Mathf.Abs(tile.transform.position.z) < Mathf.Abs(player_z) - 1 )
			{
				tile.GetComponent<GameTile>().canUse = false;
			}
			//Diagonal
			else if (Mathf.Abs(player_x) + Mathf.Abs(player_z) == (Mathf.Abs(tile.transform.position.x) + Mathf.Abs(tile.transform.position.z) + 2) 
			         || Mathf.Abs(player_x) + Mathf.Abs(player_z) == (Mathf.Abs(tile.transform.position.x) + Mathf.Abs(tile.transform.position.z) - 2)
			         || Mathf.Abs(player_x) + Mathf.Abs(player_z) == (Mathf.Abs(tile.transform.position.x) + Mathf.Abs(tile.transform.position.z)))
			{
				tile.GetComponent<GameTile>().canUse = false;
			}
			else
			{
				tile.GetComponent<GameTile>().canUse = true;
			}
		}
	}
}
