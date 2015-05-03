using UnityEngine;
using System.Collections;

public class CameraNode : StoryNode {
	
	public GameObject CameraOrientation;
	
	public StoryNode NextNode = null;
	
	override public void Display()
	{
		UpdateCamera ();
		
		StoryManager.Instance.ShowNode (NextNode);
	}

	public virtual void UpdateCamera()
	{
		Camera.main.transform.position = CameraOrientation.transform.position;
		Camera.main.transform.rotation = CameraOrientation.transform.rotation;
	}
}
