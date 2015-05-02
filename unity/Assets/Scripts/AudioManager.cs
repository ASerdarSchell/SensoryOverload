using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	static AudioManager _instance = null;
	
	public static AudioManager Instance{
		get{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<AudioManager>();
			}
			return _instance;
		}
	}

	Dictionary<string, AudioSource> _namesToAudioSources = new Dictionary<string, AudioSource> ();

	public void PlayLoop(string name, AudioClip clip, float volume)
	{
		GameObject loopObject = new GameObject ();
		loopObject.transform.parent = gameObject.transform;
		loopObject.AddComponent<AudioSource> ();
		loopObject.audio.clip = clip;
		loopObject.audio.loop = true;
		loopObject.audio.volume = volume;
		loopObject.audio.Play ();

		_namesToAudioSources [name] = loopObject.audio;
	}

	public void PlayOnce(AudioClip clip, float volume)
	{
		if (GetComponent<AudioSource> () == null)
			gameObject.AddComponent<AudioSource> ();

		audio.clip = clip;
		audio.loop = false;
		audio.volume = volume;
		audio.Play ();
	}

	public void SetPlayingVolume(string name, float volume)
	{
		_namesToAudioSources [name].volume = volume;
	}

	public void StopLoop(string name)
	{
		AudioSource source = _namesToAudioSources[name];
		source.Stop ();
		_namesToAudioSources.Remove (name);

		GameObject.Destroy (source.gameObject);
	}

}
