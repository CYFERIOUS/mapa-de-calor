using UnityEngine;
using System.Collections;

public interface IDataStorage  {

	string GetName(int key);
	string GetComments(int key);
	Vector2 GetAnnotation (int key);
	int GetTimestamp (int key);
	string GetStuff (int key);
	int GetOcurrence (int key);
	int GetTotalKey();

	void SetName (int key, string val);
	void SetTotalKey(int val);
	void SetComments (int key, string val);
	void SetAnnotation (int key, Vector2 val);
	void SetTimestamp (int key, int val);
	void SetStuff (int key, string val);
	void SetOcurrence (int key, int val);
	void save();
}
