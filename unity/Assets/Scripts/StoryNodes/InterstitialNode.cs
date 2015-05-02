using UnityEngine;
using System.Collections;

public class InterstitialNode : StoryNode {

	public Sprite Image = null;
	public string DialogueText = "";
	public StoryNode NextNode = null;
	
	override public void Display()
	{
		UIManager.Instance.InterstitialUI.DialogueText.text = DialogueText;
		UIManager.Instance.InterstitialUI.DisplayImage.sprite = Image;
		
		UIManager.Instance.InterstitialUI.gameObject.SetActive(true);
		
		UIManager.Instance.InterstitialUI.NextButton.onClick.AddListener (OnClick);
	}
	
	override public void Dismiss()
	{
		UIManager.Instance.InterstitialUI.gameObject.SetActive(false);
	}
	
	public void OnClick()
	{
		StoryManager.Instance.ShowNode (NextNode);
	}
}
