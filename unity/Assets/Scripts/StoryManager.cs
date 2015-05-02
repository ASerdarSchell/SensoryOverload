using UnityEngine;
using System.Collections;

public class StoryManager : MonoBehaviour {

	public StoryNode StartingNode = null;

	public StoryNode CurrentNode = null;


	static StoryManager _instance = null;
	
	public static StoryManager Instance{
		get{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<StoryManager>();
			}
			return _instance;
		}
	}

	// Use this for initialization
	void Start () {
		StartingNode.Display();
		CurrentNode = StartingNode;
	}
	
	public void ShowNode(StoryNode nextNode)
	{
		CurrentNode.Dismiss ();
		CurrentNode = nextNode;
		if (CurrentNode != null)
			CurrentNode.Display ();
		else
			Application.LoadLevel (0);
	}
}
