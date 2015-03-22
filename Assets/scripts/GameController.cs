using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject ai;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void PlayerOneTurn ()
	{
		print ( "Player one's turn." );
	}

	void PlayerTwoTurn ()
	{
		print ( "Player two's turn." );
	}
}
