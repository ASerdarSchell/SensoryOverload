using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {

	public int SceneIndexToLoad = 0;

	public void OnClick()
	{
		Application.LoadLevel (SceneIndexToLoad);
	}
}
