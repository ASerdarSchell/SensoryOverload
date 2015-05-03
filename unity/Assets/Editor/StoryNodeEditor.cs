using UnityEngine;
using System.Collections;
using UnityEditor;

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
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "DialogueText");

		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((DialogueNode)target).NextNode = nextNode;
		}
	}
}

[CustomEditor(typeof(AudioNode))]
public class AudioNodeEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((AudioNode)target).NextNode = nextNode;
		}
	}
}

[CustomEditor(typeof(CameraNode))]
public class CameraNodeEditor : Editor {
	
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
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "DialogueText");
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((InterstitialNode)target).NextNode = nextNode;
		}
	}
}

[CustomEditor(typeof(SetActiveNode))]
public class SetActiveNodeEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((SetActiveNode)target).NextNode = nextNode;
		}
	}
}

[CustomEditor(typeof(ChoiceNode))]
public class ChoiceNodeEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		StoryNodeHelper.DrawTextBox(serializedObject, "DialogueText");

		if (GUILayout.Button ("Add Choice Option")) {
			((ChoiceNode)target).gameObject.AddComponent<ChoiceOptionNode>();
		}
	}
}

[CustomEditor(typeof(PreviousChoiceNode))]
public class PreviousChoiceNodeEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		if (GUILayout.Button ("Add Choice Option")) {
			((PreviousChoiceNode)target).gameObject.AddComponent<ChoiceOptionNode>();
		}
	}
}

[CustomEditor(typeof(CameraLerpNode))]
public class CameraLerpNodeEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
		StoryNode nextNode = StoryNodeHelper.DrawCreateHelper (((MonoBehaviour)target).gameObject);
		if (nextNode != null) {
			((CameraLerpNode)target).NextNode = nextNode;
		}
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
