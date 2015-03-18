using UnityEngine;
using System.Collections;

public class EditorInputGenerator : MonoBehaviour, InputGenerator {

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
		if (Input.GetMouseButtonDown (0)) {
			isLongPressing = true;
		}
		if (Input.GetMouseButtonUp (0)) {
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
