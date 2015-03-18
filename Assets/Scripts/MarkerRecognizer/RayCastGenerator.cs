using UnityEngine;
using System.Collections;

public class RayCastGenerator : MonoBehaviour,InterfaceRayCastGenerator {

	protected InputReader inputReader;
	protected Recognizer recognizer;

	// Use this for initialization
	void Start () {
		SetUpInputReader ();
	}
	
	// Update is called once per frame
	void Update () {
		recognizer.ReturnsObject ();
	}

	public void SetUpInputReader ()
	{
		inputReader = new InputReader ();
		inputReader.SetGenerator (GetValidInputGenerator());
		inputReader.TapExecuted +=()=>{
			ReturnsObject();
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

	public bool ReturnsObject ()
	{
		return true;
	}
}
