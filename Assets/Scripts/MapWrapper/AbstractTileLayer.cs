using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface AbstractTileLayer
{
	GameObject gameObject {
		get;
		set;
	}

	string Key {
		get;
		set;
	}
}

