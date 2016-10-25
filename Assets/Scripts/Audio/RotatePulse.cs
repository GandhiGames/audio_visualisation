using UnityEngine;
using System.Collections;

public class RotatePulse : MonoBehaviour
{

	
	public int detail = 500;
	public float amplitude = 0.1f;

	void Update ()
	{
		float[] info = new float[detail];
		
		AudioListener.GetOutputData (info, 0); 
		
		float packagedData = 0f;
		
		for (var x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info [x]);   
		}

		transform.Rotate (Vector3.back * (packagedData * amplitude));

	}
}
