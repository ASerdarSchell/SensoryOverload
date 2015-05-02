using UnityEngine;
using System.Collections;

public class CameraNode : StoryNode {
	
	public GameObject CameraOrientation;
	
	public StoryNode NextNode = null;
	
	override public void Display()
	{
		Camera.current.transform.position = CameraOrientation.transform.position;
		Camera.current.transform.rotation = CameraOrientation.transform.rotation;
		
		StoryManager.Instance.ShowNode (NextNode);
	}
}
