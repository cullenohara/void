using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	void EnemysTurn ()
	{

	}

	void PlayersTurn ()
	{
		GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Player>().canMove = true;
	}
	
}
