using UnityEngine;
using System.Collections;

public interface IFormDataLoader {

	void SetStorage(IDataStorage storage);
	FormData Load();

}
