using UnityEngine;
using System.Collections;

public class GameTile : MonoBehaviour {

	public int tileId;
	public GameObject bombPrefab;

	void Start ()
	{
		bombPrefab = GameObject.FindGameObjectWithTag("bomb");
	}

	void OnMouseEnter ()
	{
		print("poop.");
		bombPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

}
