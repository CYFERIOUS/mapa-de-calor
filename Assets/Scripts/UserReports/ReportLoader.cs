using UnityEngine;
using System.Collections;

public class ReportLoader : IFormDataLoader {

	private IDataStorage storage;

	public void SetStorage(IDataStorage storage){
		this.storage = storage;
	}

	public FormData Load(){
		return null;
	}

}
