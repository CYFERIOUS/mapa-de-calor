using UnityEngine;
using System.Collections;

public interface IDataStorage  {

	string GetName();
	int GetKey();
	string GetComments();
	Vector2 GetAnnotation ();
	int GetTimestamp ();
	string GetStuff ();
	int GetOcurrence ();
	int GetTotalKey();

	void SetName (string val);
	void SetKey (int val);
	void SetTotalKey(int val);
	void SetComments (string val);
	void SetAnnotation (Vector2 val);
	void SetTimestamp (int val);
	void SetStuff (string val);
	void SetOcurrence (int val);
	void save();
}
