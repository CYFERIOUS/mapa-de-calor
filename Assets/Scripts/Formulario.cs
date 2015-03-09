using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Formulario : MonoBehaviour {

	protected string name = "name";
	protected string comments = "comments";
	protected Vector2 annotation = new Vector2(1,2);
	protected int timestamp = 338498400;
	protected string stuff = "article";
	protected int ocurrence = (int)Ocurrence.Assault;

	private ReportSaver reportSaver;
	
	void Start() {
		reportSaver = new ReportSaver ();
		EnviarFormulario ();
	}

	private void EnviarFormulario(){
		FormData data = CreateFormData ();
		reportSaver.SetStorage (TestAppConfig.GetStorage());
		reportSaver.Save (data);
	}

	private FormData CreateFormData(){
		FormData data = new FormData ();
		data.name = name;
		data.comments = comments;
		data.annotation = annotation;
		data.timestamp = timestamp;
		data.stuff = stuff;
		data.ocurrence = ocurrence;
		return data;
	}
}

public class TestAppConfig{

	static public IDataStorage GetStorage(){
		return new PlayerPrefStorage ();
	}
}

