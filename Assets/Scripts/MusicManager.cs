using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

	public AudioClip[] audioClips;
	public AudioSource[] audioSources;
	private int _currentClipIndex, _currentAudioSource;

	private AudioSource _currentAudio { get { return audioSources [_currentAudioSource]; } }
	private AudioSource _nextAudio { get { return audioSources [(_currentAudioSource + 1) % audioSources.Length]; } }

	private AudioClip _currentClip { get { return audioClips [_currentClipIndex]; } }
	private AudioClip _nextClip { get { return audioClips [(_currentClipIndex + 1) % audioClips.Length]; } }

	private bool _canChage = true;

	// Use this for initialization
	void Start ()
	{
		_currentClipIndex = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E) && _canChage) {
			_canChage = false;
			StartCoroutine (ChangeMusic ());
		}
	}

	private void QueueNextTrack ()
	{
		_currentAudioSource = (_currentAudioSource + 1) % audioSources.Length;
		_currentClipIndex = (_currentClipIndex + 1) % audioClips.Length;

		_nextAudio.clip = _nextClip;
	}

	private IEnumerator ChangeMusic ()
	{
		float fTimeCounter = 0f;

		_nextAudio.Play ();

		while (!(Mathf.Approximately(fTimeCounter, 1f))) {
			fTimeCounter = Mathf.Clamp01 (fTimeCounter + Time.deltaTime);
			_currentAudio.volume = 1f - fTimeCounter;
			_nextAudio.volume = fTimeCounter;
			yield return new WaitForSeconds (0.02f);
		}

		QueueNextTrack ();

		_canChage = true;
	}
}
