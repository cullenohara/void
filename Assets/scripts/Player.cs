using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public List<GameObject> tiles = new List<GameObject>();
	public Vector3 clickPos;

	public bool canMove = true;
	public bool canAttack = false;
	public bool onCooldown = false;

	public Vector3 left;
	public Vector3 right;
	public Vector3 up;
	public Vector3 down;

	public string facingDirection = "right";

	public Transform temp;
	public Transform useItem;

	private GameObject[] allWeapons;

	void Start ()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("tile"))
		{
			go.GetComponent<GameTile>().tileId = go.transform.position;
			tiles.Add(go);
		}
	}
	
	void Update ()
	{
		if(canMove == true)
		{
			Move ();
		}
		if(canAttack == true)
		{
			Attack ();
		}

		transform.position = Vector3.MoveTowards(transform.position, new Vector3(clickPos.x, transform.position.y, clickPos.z + 0.3f), Time.deltaTime * 2);
		CheckTiles();

		left = new Vector3(transform.position.x - 1, transform.position.y - 0.1f, transform.position.z - 0.3f);
		right = new Vector3(transform.position.x + 1, transform.position.y - 0.1f, transform.position.z - 0.3f);
		up = new Vector3(transform.position.x, transform.position.y - 0.1f, (transform.position.z - 0.3f) + 1);
		down = new Vector3(transform.position.x, transform.position.y - 0.1f, (transform.position.z - 0.3f) - 1);
	}

	//Checks every tile in the scene to see which tiles the player can move to
	//Players can only move one space at a time
	//Players cannot move diagonally
	void CheckTiles ()
	{
	
		foreach(GameObject tile in tiles)
		{
			if(tile.GetComponent<GameTile>().tileId == left || tile.GetComponent<GameTile>().tileId == right
			   || tile.GetComponent<GameTile>().tileId == up || tile.GetComponent<GameTile>().tileId == down)
			{
				tile.GetComponent<GameTile>().canUse = true;
			}
			else
			{
				tile.GetComponent<GameTile>().canUse = false;
			}
		}

	}

	void Move ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "tile" && hit.transform.gameObject.GetComponent<GameTile>().inUse == false 
				    && hit.transform.gameObject.GetComponent<GameTile>().canUse == true && onCooldown == false)
				{
					clickPos = hit.transform.position;					
					onCooldown = true;
					StartCoroutine("Cooldown");
					canMove = false;
					canAttack = true;
					if(clickPos == left && facingDirection == "right")
					{
						transform.localScale -= new Vector3(2,0,0);
						facingDirection = "left";
					}
					if(clickPos == right && facingDirection == "left")
					{
						transform.localScale += new Vector3(2,0,0);
						facingDirection = "right";
					}
				}
			}
		}
	}

	void Attack ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "tile" && hit.transform.gameObject.GetComponent<GameTile>().inUse == false && onCooldown == false)
				{
					onCooldown = true;
					StartCoroutine("Cooldown");
					canMove = true;
					canAttack = false;
					EndTurn();
					temp = Instantiate(useItem, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 0.1f, hit.collider.transform.position.z), Quaternion.Euler(90, 0, 0)) as Transform;
					temp.SendMessage("SetWeaponType", 1, SendMessageOptions.RequireReceiver);
					temp.GetComponent<Weapon>().ParentTile = hit.collider.transform.position;
				}
			}
		}
	}

	IEnumerator Cooldown ()
	{
		yield return new WaitForSeconds(2);
		onCooldown = false;
	}

	void EndTurn ()
	{
		allWeapons = GameObject.FindGameObjectsWithTag("bomb");
		foreach (GameObject weapon in allWeapons)
		{
			weapon.BroadcastMessage("SetCount", SendMessageOptions.DontRequireReceiver);
		}
	}


}//EOF
