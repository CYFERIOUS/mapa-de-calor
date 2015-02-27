using UnityEngine;
using System.Collections;

public interface IFormDataSaver  {

	void SetStorage(IDataStorage storage);
	void Save(FormData data);
}
