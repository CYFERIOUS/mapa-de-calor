using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ReportSaver : IFormDataSaver {

	private IDataStorage storage;
	private Vector2 coordinates;
	private int actualKey;
	private int keyTotals;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
		keyTotals = storage.GetTotalKey();
		actualKey = keyTotals;
	}

	public void SetKey(int val) {
		actualKey = val;
	}
	
	public void Save(FormData data){
		SetKeyToSave ();
		storage.SetKey (actualKey);
		storage.SetName (data.name);
		storage.SetComments (data.comments);
		storage.SetAnnotation (data.annotation);
		storage.SetTimestamp (data.timestamp);
		storage.SetStuff (data.stuff);
		storage.SetOcurrence (data.ocurrence);
		storage.SetTotalKey (keyTotals);
		storage.save ();
	}

	private void SetKeyToSave () {
		if (!isValidKey(actualKey)) {
			storage.SetKey (keyTotals);
			SetKey (keyTotals);
			++keyTotals;
		}
	}

	public bool isValidKey(int key) {
		return (key >= 0 && key < keyTotals);
	}
}

public enum Ocurrence{
	NonSpecified,
	Assault,
	Thievery
}