using UnityEngine;
using System.Collections;

public class DeviceInputGenerator : MonoBehaviour, InputGenerator {

private bool generatedLongPress=false;

#if UNITY_EDITOR
	public bool GeneratedLongPress ()
	{
		return generatedLongPress;
	}
	public bool GeneratedTap ()
	{
		return false;
	}
#else
	
	public bool GeneratedLongPress ()
	{
		return generatedLongPress;
	}
	public bool GeneratedTap ()
	{
		return false;
	}
	
	const float timeToLongPress = 1f;
	
	private float timeSincePress = 0f;
	private bool isLongPressing;
	
	void Update () {
		generatedLongPress = false;
		if (Input.GetTouch(0).phase==TouchPhase.Began) {
			isLongPressing = true;
		}
		if (Input.GetTouch(0).phase==TouchPhase.Ended) {
			isLongPressing = false;
		}
		
		if (isLongPressing) {
			timeSincePress += Time.deltaTime;
			if (timeSincePress >= timeToLongPress)
			{
				isLongPressing = false;
				timeSincePress = 0;
				generatedLongPress = true;
			}
		} else {
			timeSincePress = 0;
		}
	}
#endif
}
