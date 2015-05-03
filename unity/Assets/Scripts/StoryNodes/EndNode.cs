using UnityEngine;
using System.Collections;

public class EndNode : StoryNode {
	public override void Display()
	{
		UIManager.Instance.EndPanelUI.SetActive(true);
	}

}
