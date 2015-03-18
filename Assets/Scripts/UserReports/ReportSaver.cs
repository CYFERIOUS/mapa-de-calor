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
		storage.SetName (actualKey, data.name);
		storage.SetComments (actualKey, data.comments);
		storage.SetAnnotation (actualKey, data.annotation);
		storage.SetTimestamp (actualKey, data.timestamp);
		storage.SetStuff (actualKey, data.stuff);
		storage.SetOcurrence (actualKey, data.ocurrence);
		storage.SetTotalKey (keyTotals);
		storage.save ();
	}

	private void SetKeyToSave () {
		if (!isValidKey(actualKey)) {
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