using UnityEngine;
using System.Collections;
using UnitySlippyMap;

public class ConcreteMarkerGenerator : MarkerGenerator {

	private Map map;

	public ConcreteMarkerGenerator(Map mapInstance){
		map = mapInstance;
	}
	
	protected override AbstractMarker CreateMarkerInstance (BaseCoordinates location)
	{	GameObject markerGO = CreateMarkerGameObject (Tile.AnchorPoint.BottomCenter, DefaultTexture, 4000, new Vector3 (1.0f, 1.0f, 1.0f) / 27);
		ConcreteMarker marker = map.CreateMarker<ConcreteMarker> ("Marker", new double[2] {
			location.Longitude,
			location.Latitude
		}, markerGO);
		marker.Texture = DefaultTexture;
		return marker;
	}

	public override void DrawUserLocationMarker ()
	{
		DrawGPSUserLocation ();
	}

	private void DrawGPSUserLocation ()
	{
		GameObject markerGO = CreateMarkerGameObject (Tile.AnchorPoint.MiddleCenter,UserLocationTexture, 4001, new Vector3 (1.0f, 1.0f, 1.0f) / 27);
		map.SetLocationMarker<LocationMarker> (markerGO);
	}


	private GameObject CreateMarkerGameObject (Tile.AnchorPoint anchorPoint, Texture mainTexture, int renderQueue, Vector3 localScale)
	{
		GameObject go = Tile.CreateTileTemplate (anchorPoint).gameObject;
		go.renderer.material.mainTexture = mainTexture;
		go.renderer.material.renderQueue = renderQueue;
		go.transform.localScale = localScale;
		return go;

	}

		
}
