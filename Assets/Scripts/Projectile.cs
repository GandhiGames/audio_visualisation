using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
