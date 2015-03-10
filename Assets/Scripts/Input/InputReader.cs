using UnityEngine;
using System.Collections;
using System;

public class InputReader {

	private InputGenerator inputGenerator;

	public Action TapExecuted {
		get;
		set;
	}

	public Action LongPressExecuted {
		get;
		set;
	}

	public void SetGenerator(InputGenerator inputGenerator)
	{
		this.inputGenerator = inputGenerator;
	}

	public void Update ()
	{
		if (inputGenerator.GeneratedLongPress())
			if (LongPressExecuted != null)
				LongPressExecuted ();
		if (inputGenerator.GeneratedTap ()) {
			if(TapExecuted!=null){
				TapExecuted();
			}
		}
	}
}
