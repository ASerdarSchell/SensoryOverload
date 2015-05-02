using UnityEngine;
using System.Collections;

public class AudioNode : StoryNode {

	public enum AudioFunction
	{
		Idle,
		PlayLoop,
		PlayOnce,
		SetVolume,
		Stop
	}

	public string AudioName = "";

	public AudioClip Clip;
	public AudioFunction Function;
	public float Volume;

	public StoryNode NextNode = null;
	
	override public void Display()
	{
		if (Function == AudioFunction.PlayLoop)
			AudioManager.Instance.PlayLoop (AudioName, Clip, Volume);
		else if (Function == AudioFunction.PlayOnce)
			AudioManager.Instance.PlayOnce (Clip, Volume);
		else if (Function == AudioFunction.SetVolume)
			AudioManager.Instance.SetPlayingVolume (AudioName, Volume);
		else if (Function == AudioFunction.Stop)
			AudioManager.Instance.StopLoop (AudioName);

		StoryManager.Instance.ShowNode (NextNode);
	}
}
