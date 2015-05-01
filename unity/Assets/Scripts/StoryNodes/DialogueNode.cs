using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueNode : StoryNode {

	public string DialogueText = "";
	public StoryNode NextNode = null;

	override public void Display()
	{
		UIManager.Instance.DialogueUI.DialogueText.text = DialogueText;

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
