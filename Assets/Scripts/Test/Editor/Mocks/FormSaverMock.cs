using UnityEngine;
using System.Collections;

public class FormSaverMock : IFormDataSaver {

	private IDataStorage storage;
	private Vector2 coordinates;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}

	public void Save(FormData data){
		storage.SetName (data.name);
		storage.SetKey (data.key);
		storage.SetComments (data.comments);
		storage.SetAnnotation (data.annotation);
		storage.SetTimestamp (data.timestamp);
		storage.SetStuff (data.stuff);
		storage.SetOcurrence (data.ocurrence);
	}

	public FormData Load() {
		return new FormData ();
	}

}
