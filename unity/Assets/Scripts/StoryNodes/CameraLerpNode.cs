using UnityEngine;
using System.Collections;

public class CameraLerpNode : CameraNode {

	public float timeToLerp = 1.0f;

	override public void Display()
	{
		RunCamera ();
		

	}
	
	override public void UpdateCamera()
	{
		StartCoroutine (LerpCoroutine(false));

		//Camera.main.transform.position = CameraOrientation.transform.position;
		//Camera.main.transform.rotation = CameraOrientation.transform.rotation;


	}

	public void RunCamera()
	{
		StartCoroutine (LerpCoroutine(true));
	}

	IEnumerator LerpCoroutine(bool clearOnComplete)
	{
		Vector3 StartPos = Camera.main.transform.position;
		Quaternion StartRot = Camera.main.transform.rotation;
		float StartTime = Time.time;

		Debug.Log ("Time: " + StartTime);

		while (StartTime + timeToLerp > Time.time) {
			float percent = (Time.time - StartTime) / timeToLerp;
			Camera.main.transform.rotation = Quaternion.Lerp(StartRot, CameraOrientation.transform.rotation, percent);
			Camera.main.transform.position = Vector3.Lerp (StartPos, CameraOrientation.transform.position, percent);
			Debug.Log(StartPos.ToString() + " " + CameraOrientation.transform.position.ToString() + " " + percent.ToString() + " " + Vector3.Lerp (StartPos, CameraOrientation.transform.position, percent));
			yield return null;
		}
		StartTime = Time.time;

		Debug.Log ("Time: " + StartTime);

		while (StartTime + timeToLerp > Time.time) {
			float percent = (Time.time - StartTime) / timeToLerp;
			Camera.main.transform.rotation = Quaternion.Lerp(CameraOrientation.transform.rotation, StartRot, percent);
			Camera.main.transform.position = Vector3.Lerp (CameraOrientation.transform.position, StartPos, percent);
			yield return null;
		}

		Debug.Log ("Time: " + Time.time);

		if (clearOnComplete)
			StoryManager.Instance.ShowNode (NextNode);

	}
}
