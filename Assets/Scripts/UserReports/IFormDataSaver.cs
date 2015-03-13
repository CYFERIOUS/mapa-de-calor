using UnityEngine;
using System.Collections;

public interface IFormDataSaver  {

	void SetStorage(IDataStorage storage);
	void SetKey(int val);
	void Save(FormData data);

}