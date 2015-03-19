using UnityEngine;
using System.Collections;

public class ReportLoader : IFormDataLoader {

	private IDataStorage storage;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}

	public int GetTotalKey() {
		return storage.GetTotalKey ();
	}

	public FormData Load(int key){
		FormData data = new FormData ();

		if(isValidKey(key)) {
			data.key = key;
			data.name = storage.GetName (key);
			data.annotation = storage.GetAnnotation (key);
			data.stuff = storage.GetStuff(key);
			data.comments = storage.GetComments(key);
			data.timestamp = storage.GetTimestamp(key);
			data.ocurrence = storage.GetOcurrence(key);
		}
		return data;
	}

	public bool isValidKey(int key) {
		return (key >= 0 && key < GetTotalKey());
	}

}
