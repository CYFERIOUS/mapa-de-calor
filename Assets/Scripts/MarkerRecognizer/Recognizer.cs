using UnityEngine;
using System.Collections;

public interface Recognizer {

	bool ReturnsObject ();
	/*{
		Ray ray;
		RaycastHit hit;

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray,out hit)){
			Debug.Log(hit.collider.name);
			return true;
		}
		return false;

	}*/
}
