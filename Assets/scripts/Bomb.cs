using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float sphereRadius = 1;
	public Renderer rend;
	public Color bombColor;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		bombColor = rend.material.color;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			rend.material.color = Color.red;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			rend.material.color = bombColor;
		}
	}
}
