using UnityEngine;
using System.Collections;

public interface IDataStorage  {

	string GetName();
	string GetComments();
	Vector2 GetAnnotation ();
	int GetTimestamp ();
	string GetStuff ();
	int GetRobbery ();

	void SetName (string val);
	void SetComments (string val);
	void SetAnnotation (Vector2 val);
	void SetTimestamp (int val);
	void SetStuff (string val);
	void SetRobbery (int val);
	void save();
}
