using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ReportSaver : IFormDataSaver {

	private IDataStorage storage;
	private Vector2 coordinates;
	
	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}
	
	public void Save(FormData data){
		storage.SetName (data.name);
		storage.SetComments (data.comments);
		storage.SetAnnotation (data.annotation);
		storage.SetTimestamp (data.timestamp);
		storage.SetStuff (data.stuff);
		storage.SetOcurrence (data.ocurrence);
		storage.save ();
	}

	public FormData Load() {
		FormData data = new FormData ();
		data.name = storage.GetName ();
		data.comments = storage.GetComments ();
		data.annotation = storage.GetAnnotation ();
		data.timestamp = storage.GetTimestamp ();
		data.stuff = storage.GetStuff ();
		data.ocurrence = storage.GetOcurrence ();

		return data;
	}
}

public enum Ocurrence{
	NonSpecified,
	Assault,
	Thievery
}