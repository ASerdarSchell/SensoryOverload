using UnityEngine;
using System.Collections;

public class ChoiceOptionNode : MonoBehaviour {

	public string ChoiceText = "";
	public StoryNode NextNode = null;

	public void OnClick()
	{
		ChoiceNode parentNode = GetComponent<ChoiceNode> ();
		if (parentNode != null) {
			ChoiceOptionNode[] choices = GetComponents<ChoiceOptionNode>();

		}

		StoryManager.Instance.ShowNode (NextNode);
	}
}
