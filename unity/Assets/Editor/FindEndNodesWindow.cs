using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FindEndNodesWindow : EditorWindow {


	static EditorWindow instance = null;

	[MenuItem ("Sensory Overload/Find End Nodes")]
	public static void  ToggleWindow () {
		if (instance == null)
			instance = EditorWindow.GetWindow(typeof(FindEndNodesWindow));
		else 
		{
			instance.Close();
			instance = null;
		}
	}

	List<StoryNode> EmptyNextNodes = null;

	void Search ()
	{
		EmptyNextNodes = new List<StoryNode> ();

		StoryNode[] foundNodes = GameObject.FindObjectsOfType<StoryNode> ();
		Debug.Log ("Searching. found:" + foundNodes.Length);

		foreach (StoryNode currentNode in foundNodes) {
			if (currentNode as AudioNode && ((AudioNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as CameraNode && ((CameraNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as ChoiceOptionNode && ((ChoiceOptionNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as DialogueNode && ((DialogueNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as InterstitialNode && ((InterstitialNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as PreviousChoiceNode && ((PreviousChoiceNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as SetActiveNode && ((SetActiveNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}

			if (currentNode as CameraLerpNode && ((CameraLerpNode)currentNode).NextNode == null)
			{
				EmptyNextNodes.Add(currentNode);
			}
		}

	}

	Vector2 scroll = new Vector2();

	void OnGUI () {
		if (EmptyNextNodes == null)
			Search ();
		if (GUILayout.Button ("Refresh List"))
			Search ();

		scroll = GUILayout.BeginScrollView (scroll);

		foreach (StoryNode currentNode in EmptyNextNodes) {
			if (currentNode == null)
				continue;
			string name = currentNode.name;
			if (string.IsNullOrEmpty(name))
				name = "Null or Empty Named Node";

			if (GUILayout.Button(name))
				Selection.activeObject = currentNode;
		}
		GUILayout.EndScrollView ();
	}

}
