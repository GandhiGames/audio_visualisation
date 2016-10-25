using UnityEngine;
using System.Collections;

public class ShapePulse : MonoBehaviour
{

	public int detail = 500;
	public float amplitude = 0.1f;
	
	private Vector3 _startScale;
	
	void Start ()
	{
		_startScale = transform.localScale;
	}
	
	void Update ()
	{
		float[] info = new float[detail];
		
		AudioListener.GetOutputData (info, 0); 
		
		float packagedData = 0f;
		
		for (var x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info [x]);   
		}
		
		transform.localScale = new Vector3 ((packagedData * amplitude) + _startScale.x, (packagedData * amplitude) + _startScale.y, 
		                                    (packagedData * amplitude) + _startScale.z);
	}
}
