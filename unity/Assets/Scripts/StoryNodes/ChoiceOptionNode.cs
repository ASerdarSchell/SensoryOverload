using UnityEngine;
using System.Collections;

public class ChoiceOptionNode : MonoBehaviour {

	public string ChoiceText = "";
	public StoryNode NextNode = null;

	public void OnClick()
	{
		StoryManager.Instance.ShowNode (NextNode);
	}
}
