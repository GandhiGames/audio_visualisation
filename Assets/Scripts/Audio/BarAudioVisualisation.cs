﻿using UnityEngine;
using System.Collections;

public class BarAudioVisualisation : MonoBehaviour
{
	public float amplitude = 0.1f;
	
	private Vector3 _startScale;
	private float _randomAmplitude;
	private int _detail;

	void Start ()
	{
		_startScale = transform.localScale;
		_detail = Random.Range (300, 700);
		_randomAmplitude = Random.Range (0.1f, 7f);
	}
	
	void LateUpdate ()
	{
		float[] info = new float[_detail];

		AudioListener.GetOutputData (info, 0); 

		float packagedData = 0f;
		
		for (var x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info [x]);   
		}
		
		transform.localScale = new Vector3 (_startScale.x, (packagedData * amplitude * _randomAmplitude) + _startScale.y, _startScale.z);
	}
}
