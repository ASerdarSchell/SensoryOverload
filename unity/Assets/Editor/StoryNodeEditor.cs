using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class StoryNodeHelper
{
	public static string[] options = new string[] { "Create Node", "AudioNode", "CameraNode", "ChoiceNode", "DialogueNode", "PreviousChoiceNode", "InterstitialNode", "SetActiveNode", "EndNode", "CameraLerpNode" };
	public static System.Type[] optionType = new System.Type[] { typeof(string), typeof(AudioNode), typeof(CameraNode), typeof(ChoiceNode), typeof(DialogueNode), typeof(PreviousChoiceNode), typeof(InterstitialNode), typeof(SetActiveNode), typeof(EndNode), typeof(CameraLerpNode) };

	public static StoryNode DrawCreateHelper(GameObject parent)
	{
		int create = EditorGUILayout.Popup (0, options);
		GameObject newChild;

		if (create != 0) {
			newChild = new GameObject();
			newChild.name = options[create];
			newChild.transform.parent = parent.transform;
			StoryNode node = (StoryNode)newChild.AddComponent(optionType[create]);
			Selection.activeObject = newChild;

			return node;
		}

		return null;
	}

	public static StoryNode[] FindParents(StoryNode[] foundParents, StoryNode childNode)
	{
		StoryNode[] foundNodes = foundParents;
		if (GUILayout.Button ("Find Parents")) {
			StoryNode[] newNodes = GameObject.FindObjectsOfType<StoryNode> ();

			List<StoryNode> newParents = new List<StoryNode>();

			foreach (StoryNode currentNode in newNodes){
				if (InsertNodeWindow.getNextNode(currentNode) == childNode)
					newParents.Add(currentNode);
			}

			foundNodes = newParents.ToArray();
		}

		if (foundNodes.Length > 0)
			EditorGUILayout.Space ();

		foreach (StoryNode currentNode in foundNodes) {
			if (currentNode == null)
				continue;
			string name = currentNode.name;
			if (string.IsNullOrEmpty(name))
				name = "Null or Empty Named Node";
			
			if (GUILayout.Button(name))
				Selection.activeObject = currentNode;
		}

		return foundNodes;
	}

	public static void DrawTextBox(SerializedObject sobj, string propName)
	{
		sobj.Update ();
		SerializedProperty propery = sobj.FindProperty (propName);
		GUILayout.Label (propName);
		EditorStyles.textField.wordWrap = true;
		propery.stringValue = EditorGUILayout.TextArea( propery.stringValue );
		sobj.ApplyModifiedProperties ();

	}
}

[CustomEditor(typeof(DialogueNode))]
public class DialogueNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "DialogueText");

		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((DialogueNode)target).NextNode = nextNode;
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(AudioNode))]
public class AudioNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((AudioNode)target).NextNode = nextNode;
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(CameraNode))]
public class CameraNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		GUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Test Camera")) {
			((CameraNode)target).UpdateCamera();
		}

		if (GUILayout.Button ("Reset Camera")) {
			StoryManager.Instance.UpdateCamera();
		}

		GUILayout.EndHorizontal ();

		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((CameraNode)target).NextNode = nextNode;
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(ChoiceOptionNode))]
public class ChoiceOptionNodeEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "ChoiceText");
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((ChoiceOptionNode)target).NextNode = nextNode;
		}
	}
}

[CustomEditor(typeof(InterstitialNode))]
public class InterstitialNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "DialogueText");
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((InterstitialNode)target).NextNode = nextNode;
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(SetActiveNode))]
public class SetActiveNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((SetActiveNode)target).NextNode = nextNode;
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(ChoiceNode))]
public class ChoiceNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "DialogueText");

		if (GUILayout.Button ("Add Choice Option")) {
			((ChoiceNode)target).gameObject.AddComponent<ChoiceOptionNode>();
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(PreviousChoiceNode))]
public class PreviousChoiceNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		if (GUILayout.Button ("Add Choice Option")) {
			((PreviousChoiceNode)target).gameObject.AddComponent<ChoiceOptionNode>();
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(CameraLerpNode))]
public class CameraLerpNodeEditor : Editor {

	StoryNode[] parents = new StoryNode[0];

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((CameraLerpNode)target).NextNode = nextNode;
		}

		parents = StoryNodeHelper.FindParents (parents, (StoryNode)target);
	}
}

[CustomEditor(typeof(StoryManager))]
public class StoryManagerEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		if (GUILayout.Button ("Set Camera Position")) {
			((StoryManager)target).StartingCameraPosition = Camera.main.transform.position;
			((StoryManager)target).StartingCameraRotation = Camera.main.transform.rotation;
		}
	}
}
