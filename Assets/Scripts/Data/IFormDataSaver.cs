using UnityEngine;
using System.Collections;

public interface IformSaver  {

	void Save(string val, bool isName);
	void SetStorage(IDataStorage storage);
	void SaveVector(Vector2 storage);
}
