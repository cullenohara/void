using UnityEngine;
using System.Collections;

public class GameTile : MonoBehaviour {

	public int tileId;
	public GameObject bombPrefab;
	public GameObject player;

	public bool inUse = false;

	public Vector3 clickPos;

	public bool moveX = false;
	public bool moveZ = false;

	void Start ()
	{
		bombPrefab = GameObject.FindGameObjectWithTag( "bomb" );
		player = GameObject.FindGameObjectWithTag( "Player" );
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null)
				{
					clickPos = hit.collider.transform.position;
					moveX = true;
				}
			}
		}

		player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(clickPos.x, player.transform.position.y, clickPos.z), Time.deltaTime * 3);

	}

	void GetPlayer (GameObject getPlayer)
	{
		player = getPlayer;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			print ("Colliding");
			inUse = true;
		}
	}

	void OnCollisionExit (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			inUse = false;
		}
	}

	void Move ()
	{

	}

}
