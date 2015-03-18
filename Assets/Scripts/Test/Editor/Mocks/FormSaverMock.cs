using UnityEngine;
using System.Collections;

public class FormSaverMock : IFormDataSaver {

	private IDataStorage storage;
	private Vector2 coordinates;
	private int key;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}

	public void SetKey(int val) {
		key = val;
	}

	public void Save(FormData data){
		storage.SetName (key, data.name);
		storage.SetComments (key, data.comments);
		storage.SetAnnotation (key, data.annotation);
		storage.SetTimestamp (key, data.timestamp);
		storage.SetStuff (key, data.stuff);
		storage.SetOcurrence (key, data.ocurrence);
	}

	public FormData Load() {
		return new FormData ();
	}

}
