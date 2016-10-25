using UnityEngine;
using System.Collections;

public class PulseColourWithAudio : MonoBehaviour
{
	public int detail = 500;
	public float amplitude = 0.01f;
	public Color MaxColour;
	public float RedOffset;
	public float BlueOffset;
	public float GreenOffset;
	public float AlphaOffset = 100f;
	
	private Renderer _renderer;
	
	// Use this for initialization
	void Awake ()
	{
		_renderer = GetComponent<Renderer> ();
		
		RedOffset = NormaliseOffset (RedOffset);
		BlueOffset = NormaliseOffset (BlueOffset);
		GreenOffset = NormaliseOffset (GreenOffset);
		AlphaOffset = NormaliseOffset (AlphaOffset);
		
	}
	
	private float NormaliseOffset (float offset)
	{
		if (offset > 1) {
			return offset / 255f;
		}
		
		return offset;
	}
	
	//rgb(236, 240, 241)
	
	// Update is called once per frame
	void Update ()
	{
		float[] info = new float[detail];
		
		AudioListener.GetOutputData (info, 0); 
		
		float packagedData = 0f;
		
		for (var x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info [x]);   
		}

	
		var red = Mathf.Min ((packagedData * amplitude) + RedOffset, MaxColour.r);
		var blue = Mathf.Min ((packagedData * amplitude) + BlueOffset, MaxColour.b);
		var green = Mathf.Min ((packagedData * amplitude) + GreenOffset, MaxColour.g);
		var alpha = Mathf.Min ((packagedData * amplitude) + AlphaOffset, MaxColour.a);
		
		_renderer.material.color = new Color (red, green, blue, alpha);
	}
}
