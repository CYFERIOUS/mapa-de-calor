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
	const float timeToTap = 0.3f;
	
	private float timeSincePress = 0f;
	private bool isLongPressing;
	
	void Update () {
		generatedLongPress = false;
		generatedTapPress = false;

		bool didATap = false;

		if (Input.GetMouseButtonDown (0)) {
			isLongPressing = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			if (isLongPressing)
				didATap = true;
			isLongPressing = false;
		}

		if (didATap)
		{
			if (timeSincePress <= timeToTap ){
				generatedTapPress=true;
			}
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
}
