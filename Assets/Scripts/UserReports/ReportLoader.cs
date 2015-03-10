using UnityEngine;
using System.Collections;

public class ReportLoader : IFormDataLoader {

	private IDataStorage storage;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}

	public FormData Load(){
		FormData data = new FormData ();
		data.name = storage.GetName ();
		data.annotation = storage.GetAnnotation ();
		data.stuff = storage.GetStuff();
		data.comments = storage.GetComments();
		data.timestamp = storage.GetTimestamp();
		data.ocurrence = storage.GetOcurrence();
		return data;
	}
}
