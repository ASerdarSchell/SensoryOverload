using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	static UIManager _instance = null;

	public static UIManager Instance{
		get{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<UIManager>();
			}
			return _instance;
		}
	}

	public UIChoicePanel ChoiceUI = null;
	public UIDialouePanel DialogueUI = null;
	public UIInterstitialPanel InterstitialUI = null;
}
