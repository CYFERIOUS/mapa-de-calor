using UnityEngine;
using System.Collections;

public class ReportLoader : IFormDataLoader {

	private IDataStorage storage;
	private int keyTotals;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}

	public int GetTotalKey() {
		return storage.GetTotalKey ();
	}

	public FormData Load(int key){
		FormData data = new FormData ();

		if(isValidKey(key)) {
			storage.SetKey(key);
			data.name = storage.GetName ();
			data.annotation = storage.GetAnnotation ();
			data.stuff = storage.GetStuff();
			data.comments = storage.GetComments();
			data.timestamp = storage.GetTimestamp();
			data.ocurrence = storage.GetOcurrence();
		}
		return data;
	}

	public bool isValidKey(int key) {
		return (key >= 0 && key < GetTotalKey());
	}

}
