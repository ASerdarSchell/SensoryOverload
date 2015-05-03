using UnityEngine;
using System.Collections;
using UnityEditor;

public class InsertNodeWindow : EditorWindow {

	static EditorWindow instance = null;
	
	[MenuItem ("Sensory Overload/Insert Node Window")]
	public static void  ToggleWindow () {
		if (instance == null)
			instance = EditorWindow.GetWindow(typeof(InsertNodeWindow));
		else 
		{
			instance.Close();
			instance = null;
		}
	}

	bool insertNew = false;
	StoryNode firstNode = null;
	StoryNode secondNode = null;
	int createType = 0;

	void OnGUI () {
		firstNode = (StoryNode)EditorGUILayout.ObjectField ("First Node", firstNode, typeof(StoryNode), true);
		insertNew = EditorGUILayout.Toggle ("Create New?", insertNew);
		if (insertNew) {
			createType = EditorGUILayout.Popup (createType, StoryNodeHelper.options);
		} else {
			secondNode = (StoryNode)EditorGUILayout.ObjectField ("Second Node", secondNode, typeof(StoryNode), true);
		}
		string thirdNodeMessage = "ThirdNode: ";
		StoryNode thirdNode = getNextNode (firstNode);
		if (thirdNode != null)
			thirdNodeMessage = thirdNodeMessage + thirdNode.name;
		else
			thirdNodeMessage = thirdNodeMessage + "<null>";

		GUILayout.Label (thirdNodeMessage);

		if (firstNode != null && GUILayout.Button ("Insert")) {
			if (insertNew && createType != 0) {
				GameObject newChild = new GameObject();
				newChild.name = StoryNodeHelper.options[createType];
				//newChild.transform.parent = parent.transform;
				StoryNode node = (StoryNode)newChild.AddComponent(StoryNodeHelper.optionType[createType]);
				Selection.activeObject = newChild;
				if (createType != 3 && createType != 5)
				{
					setNextNode(node, getNextNode(firstNode));
					setNextNode(firstNode, node);
				}
				else
				{
					ChoiceOptionNode childNode = newChild.AddComponent<ChoiceOptionNode>();
					setNextNode(childNode, getNextNode(firstNode));
					setNextNode(firstNode, node);
				}

				Selection.activeObject = node.gameObject;

				firstNode = null;
				secondNode = null;
			}
			else if (secondNode != null)
			{
				setNextNode(secondNode, getNextNode(firstNode));
				setNextNode(firstNode, secondNode);

				Selection.activeObject = secondNode.gameObject;

				firstNode = null;
				secondNode = null;
			}
		}


	}

	StoryNode getNextNode(StoryNode currentNode)
	{
		if (currentNode as AudioNode)
		{
			return ((AudioNode)currentNode).NextNode;
		}
		
		if (currentNode as CameraNode)
		{
			return ((CameraNode)currentNode).NextNode;
		}
		
		if (currentNode as ChoiceOptionNode)
		{
			return ((ChoiceOptionNode)currentNode).NextNode;
		}
		
		if (currentNode as DialogueNode)
		{
			return ((DialogueNode)currentNode).NextNode;
		}
		
		if (currentNode as InterstitialNode)
		{
			return ((InterstitialNode)currentNode).NextNode;
		}
		
		if (currentNode as PreviousChoiceNode)
		{
			return ((PreviousChoiceNode)currentNode).NextNode;
		}
		
		if (currentNode as SetActiveNode )
		{
			return ((SetActiveNode)currentNode).NextNode;
		}
		
		if (currentNode as CameraLerpNode)
		{
			return ((CameraLerpNode)currentNode).NextNode;
		}

		return null;
	}

	void setNextNode(StoryNode currentNode, StoryNode nextNode)
	{
		if (currentNode as AudioNode)
		{
			((AudioNode)currentNode).NextNode = nextNode;
		} else if (currentNode as CameraNode)
		{
			((CameraNode)currentNode).NextNode = nextNode;
		} else if (currentNode as ChoiceOptionNode)
		{
			((ChoiceOptionNode)currentNode).NextNode = nextNode;
		} else if (currentNode as DialogueNode)
		{
			((DialogueNode)currentNode).NextNode = nextNode;
		} else if (currentNode as InterstitialNode)
		{
			((InterstitialNode)currentNode).NextNode = nextNode;
		} else if (currentNode as PreviousChoiceNode)
		{
			((PreviousChoiceNode)currentNode).NextNode = nextNode;
		} else if (currentNode as SetActiveNode )
		{
			((SetActiveNode)currentNode).NextNode = nextNode;
		} else if (currentNode as CameraLerpNode)
		{
			((CameraLerpNode)currentNode).NextNode = nextNode;
		}
	}
}
