using UnityEngine;
using System.Collections;

public class PreviousChoiceNode : StoryNode {

	public ChoiceNode PreviousNode;
	public StoryNode NextNode = null;

	override public void Display()
	{
		ChoiceOptionNode[] optionNodes = GetComponents<ChoiceOptionNode> ();

		UIManager.Instance.DialogueUI.DialogueText.text = optionNodes[PreviousNode.SavedIndex].ChoiceText;
		
		UIManager.Instance.DialogueUI.gameObject.SetActive(true);
		
		UIManager.Instance.DialogueUI.NextButton.onClick.AddListener (OnClick);
	}
	
	override public void Dismiss()
	{
		UIManager.Instance.DialogueUI.gameObject.SetActive(false);
	}
	
	public void OnClick()
	{
		StoryManager.Instance.ShowNode (NextNode);
	}
}
