using UnityEngine;
using System.Collections;

public class MarkerRecognizer : MonoBehaviour {
	
	protected InputReader inputReader;
	// Use this for initialization
	void Start () {
		SetUpInputReader ();
	}
	
	// Update is called once per frame
	void Update () {
		inputReader.Update();
	}

	public void SetUpInputReader ()
	{
		inputReader = new InputReader ();
		inputReader.SetGenerator (GetValidInputGenerator());
		inputReader.TapExecuted +=()=>{
			//recognizer.MakeTap();
		};
	}

	private InputGenerator GetValidInputGenerator()
	{
		#if UNITY_EDITOR
		return GetComponent<EditorInputGenerator>();
		#else
		return GetComponent<DeviceInputGenerator>();
		#endif
	}

}
