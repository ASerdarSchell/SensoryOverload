using UnityEngine;
using System.Collections;

public class ChoiceNode : StoryNode {
	public string DialogueText = "";
	
	override public void Display()
	{
		UIManager.Instance.ChoiceUI.DialogueText.text = DialogueText;
		UIManager.Instance.ChoiceUI.gameObject.SetActive(true);

		ChoiceOptionNode[] optionNodes = GetComponents<ChoiceOptionNode> ();

		if (optionNodes.Length > 0) {
			UIManager.Instance.ChoiceUI.Choice1.gameObject.SetActive (true);
			UIManager.Instance.ChoiceUI.Choice1.onClick.AddListener (optionNodes [0].OnClick);
			UIManager.Instance.ChoiceUI.Choice1.onClick.AddListener (OnClick0);
		} else {
			UIManager.Instance.ChoiceUI.Choice1.gameObject.SetActive (false);
		}

		if (optionNodes.Length > 1) {
			UIManager.Instance.ChoiceUI.Choice2.gameObject.SetActive(true);
			UIManager.Instance.ChoiceUI.Choice2.onClick.AddListener (optionNodes[1].OnClick);
			UIManager.Instance.ChoiceUI.Choice1.onClick.AddListener (OnClick1);
		} else {
			UIManager.Instance.ChoiceUI.Choice2.gameObject.SetActive (false);
		}

		if (optionNodes.Length > 2) {
			UIManager.Instance.ChoiceUI.Choice3.gameObject.SetActive(true);
			UIManager.Instance.ChoiceUI.Choice3.onClick.AddListener (optionNodes[2].OnClick);
			UIManager.Instance.ChoiceUI.Choice1.onClick.AddListener (OnClick2);
		} else {
			UIManager.Instance.ChoiceUI.Choice3.gameObject.SetActive (false);
		}
	}
	
	override public void Dismiss()
	{
		UIManager.Instance.ChoiceUI.gameObject.SetActive(false);
	}

	public int SavedIndex = -1;

	public void OnClick0()
	{
		SavedIndex = 0;
	}

	public void OnClick1()
	{
		SavedIndex = 1;
	}

	public void OnClick2()
	{
		SavedIndex = 2;
	}

}
