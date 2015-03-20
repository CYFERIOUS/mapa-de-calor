#if UNITY_IPHONE || UNITY_ANDROID && !UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class DeviceInputGenerator : MonoBehaviour, InputGenerator {

private bool generatedLongPress=false;
private bool generatedTapPress=false;

	public bool GeneratedLongPress ()
	{
		return generatedLongPress;
	}
	public bool GeneratedTap ()
	{
		return generatedTapPress;
	}
	
	const float timeToLongPress = 1f;
	
	private float timeSincePress = 0f;
	private bool isLongPressing;
	
	void Update () {
		generatedLongPress = false;
		generatedTapPress = false;
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
			else{
				generatedTapPress=true;
			}
		} else {
			timeSincePress = 0;
		}
	}
}
#endif