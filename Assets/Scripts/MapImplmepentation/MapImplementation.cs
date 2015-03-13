using UnityEngine;
using System.Collections;
using UnitySlippyMap;
using System.Collections.Generic;

public class MapImplementation : AbstractMap {

	private Map map = Map.Instance;

	#region AbstractMap implementation
	public float CurrentZoom {
		get {
			return map.CurrentZoom;
		}
		set {
			map.CurrentZoom = value;
		}
	}
	public Camera CurrentCamera {
		get {
			return map.CurrentCamera;
		}
		set {
			map.CurrentCamera = value;
		}
	}
	public bool UseLocation {
		get {
			return map.UseLocation;
		}
		set {
			map.UseLocation = value;
		}
	}
	public bool InputsEnabled {
		get {
			return map.InputsEnabled;
		}
		set {
			map.InputsEnabled = value;
		}
	}

	public void SetUserLocation ()
	{
		throw new System.NotImplementedException ();
	}


	public void setOriginCoordinates (BaseCoordinates coordinates)
	{
		
		map.CenterWGS84 = new double[2] { coordinates.Latitude, coordinates.Longitude};
	}

	public void SetActiveVirtualEarthTileLayer (VirtualEarthTileLayer layer)
	{
		layer.gameObject.SetActive (true);
	}
	
	
	public void addInputDelegateKeyboard ()
	{
		map.InputDelegate += UnitySlippyMap.Input.MapInput.BasicTouchAndKeyboard; 
	}
	
	
	public List<AbstractMarker> GetMarkers ()
	{
		return new List<AbstractMarker> ();
	}
	
	public void SetActiveVirtualEarthLayer (BaseVirtualEarthLayer layer)
	{
		if (typeof(Layer) == typeof(VirtualEarthTileLayer))
			SetActiveVirtualEarthTileLayer (layer as VirtualEarthTileLayer);
	}
	
	public BaseVirtualEarthLayer createVirtualEarthLayer ()
	{
		VirtualEarthTileLayer virtualEarthLayer = map.CreateLayer<VirtualEarthTileLayer> ("VirtualEarth");
		return virtualEarthLayer;
	}
	
	public void AddMarker (AbstractMarker marker)
	{
		
	}

	#endregion

}
