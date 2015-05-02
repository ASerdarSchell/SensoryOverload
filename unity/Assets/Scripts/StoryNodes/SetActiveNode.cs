using UnityEngine;
using System.Collections;

public class SetActiveNode : StoryNode {
	
	public GameObject SetGameObject;
	public bool NewState = false;
	
	public StoryNode NextNode = null;
	
	override public void Display()
	{
		SetGameObject.SetActive (NewState);

		StoryManager.Instance.ShowNode (NextNode);
	}
}
