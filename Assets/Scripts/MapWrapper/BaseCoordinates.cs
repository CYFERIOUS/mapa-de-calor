using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCoordinates
{	public double Latitude{ get; set;}
	public double Longitude{ get; set;}
	public BaseCoordinates(double latitude, double longitude){
		Latitude = latitude;
		Longitude = longitude;
	}
}

