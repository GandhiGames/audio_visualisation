using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineAudioVisualisation : MonoBehaviour
{
	public GameObject linePrefab;
	public int maxLinesSpawned = 100;
	public int detail = 500;
	public float amplitude = 0.1f;
	public float maxOffset = 5f;
	public bool reverseY;

	private GameObject[] lines;
	private int _currentLine = 0;
	private float _startPosition;

	void Start ()
	{
		_startPosition = transform.localPosition.y;

		lines = new GameObject[maxLinesSpawned];
		for (int i = 0; i < maxLinesSpawned; i++) {
			var line = (GameObject)Instantiate (linePrefab);
			line.SetActive (false);
			lines [i] = line;
		}
	}

	void Update ()
	{
		float[] info = new float[detail];

		AudioListener.GetOutputData (info, 0); 

		float packagedData = 0f;
		
		for (var x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info [x]);   
		}

		float offset = Mathf.Clamp (packagedData * amplitude, 0, maxOffset);

		lines [_currentLine].SetActive (false);

		if (!reverseY) {
			transform.localPosition = new Vector3 (transform.localPosition.x, _startPosition + offset, transform.localPosition.z);

			lines [_currentLine].transform.position = new Vector3 (transform.position.x, transform.position.y - 5f, transform.position.z);
		
		} else {
			transform.localPosition = new Vector3 (transform.localPosition.x, _startPosition - offset, transform.localPosition.z);

			lines [_currentLine].transform.position = new Vector3 (transform.position.x, transform.position.y + 5f, transform.position.z);
		}

		lines [_currentLine].SetActive (true);

		_currentLine = (_currentLine + 1) % maxLinesSpawned;


	}
}
