using UnityEngine;
using System.Collections;

public class HealthSample : MonoBehaviour {

	public float healthAmount;
	
	public void TakeDamage(float damageAmount) {
		healthAmount -= damageAmount;
	}

}
