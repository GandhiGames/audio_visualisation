using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{

	public float speed = 15f;

	void Update ()
	{
		//transform.Rotate (0, speed * Time.deltaTime, 0);
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
