using UnityEngine;
using System.Collections;

public class CameraNode : StoryNode {
	
	public GameObject CameraOrientation;
	
	public StoryNode NextNode = null;
	
	override public void Display()
	{
		Camera.main.transform.position = CameraOrientation.transform.position;
		Camera.main.transform.rotation = CameraOrientation.transform.rotation;
		
		StoryManager.Instance.ShowNode (NextNode);
	}
}
