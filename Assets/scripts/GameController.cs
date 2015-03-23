using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject ai;
	public GameObject bomb;

	public Vector3 clickPos;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		bomb = GameObject.FindGameObjectWithTag("bomb");
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "tile" && hit.transform.gameObject.GetComponent<GameTile>().inUse == false)
				{
					clickPos = hit.transform.position;
					//bomb.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
				}
			}
		}

		player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(clickPos.x, player.transform.position.y, clickPos.z), Time.deltaTime * 3);
	}
}
