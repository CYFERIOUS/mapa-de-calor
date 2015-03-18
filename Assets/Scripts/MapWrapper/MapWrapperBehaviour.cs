using UnityEngine;
using System.Collections;
using UnitySlippyMap;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapWrapperBehaviour:MonoBehaviour
{
	public Texture	LocationTexture;
	public Texture	MarkerTexture;
	public GameObject ReportTrigger;
	public InputField DirectionInputField;

	protected InputReader inputReader;
	protected double PrivateTriggerMovementManager;
	protected bool isOnMainWindow = true;

	private MapWrapper mapWrapper;
	private AbstractMap mapImplementation;
	private MarkerGenerator markerGenerator;
	private IFormDataLoader loader;
	private AnnotationManager manager;
	public Dictionary<string, double> LastPutMarkerCoordinates = null;

	private Map map;


	void Start ()
	{	
		map = Map.Instance;
		mapImplementation = new MapImplementation ();
		mapWrapper = new MapWrapper ();
		SetupMarkerGenerator ();

		mapWrapper.MapImplementation = mapImplementation;
		mapWrapper.MarkerGenerator = markerGenerator;
		SetupMapInstance ();	
		SetUpInputReader ();
		SetUpLoader();
		SetUpManager ();
		manager.loadAnnotations();
		PrivateTriggerMovementManager = map.CenterWGS84 [0];
	}

	void SetUpManager () {
		manager = new AnnotationManager(loader, mapWrapper);
	}

	void SetUpLoader() {
		loader = new ReportLoader();
		loader.SetStorage(new PlayerPrefStorage());
	}

	public void CreateAnnotation (double latitude, double longitude){
		Coordinates location = new Coordinates (latitude, longitude);
		mapWrapper.SetMarkerInMap (location);
		Debug.Log ("Llamado desde MapWrapperBehaviour");
	}



	void Update ()
	{
		if (isOnMainWindow == true) {
			inputReader.Update ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		float resta = Mathf.Abs ((float)PrivateTriggerMovementManager - (float)map.CenterWGS84 [0]);
		
		if ( resta>0.001 && ReportTrigger.activeInHierarchy == true) {
			ReportTrigger.SetActive (false);
			RemoveLastPutMarker ();
		}
	}

	public void SetupMapInstance ()
	{	
		mapWrapper.SetCurrentCamera (Camera.main);
		mapWrapper.SetCurrentZoom (15.0f);
		mapWrapper.createVirtualEarthLayer ("Ag-ML2n_NjUqTCNOJyd9Yyr-GRfEWVmY_yboAe3A3aUL2JrE1d9er914Tfs9kgrp");
		mapWrapper.setOriginCoordinates (new Coordinates (-74.084046, 4.638194));
		mapWrapper.EnableUseLocation ();
		mapWrapper.addInputDelegateKeyboard ();
		mapWrapper.EnableInputs ();
	}

	public void SetupMarkerGenerator ()
	{
		markerGenerator = new ConcreteMarkerGenerator (Map.Instance);
		markerGenerator.DefaultTexture = MarkerTexture;
	}

	public void SetUpInputReader(){
		inputReader = new InputReader ();
		inputReader.SetGenerator (GetValidInputGenerator());
		inputReader.LongPressExecuted +=()=>{
			SetSingleMarkerOnMap();
			ReportTrigger.SetActive (true);
			PrivateTriggerMovementManager = map.CenterWGS84 [0];
		};
	}

	
	public void RemoveLastPutMarker ()
	{
		RemoveMarker (LastPutMarkerCoordinates ["longitude"],LastPutMarkerCoordinates ["latitude"]);
	}

	public void RemoveMarker(double latitude, double longitude){
		Marker[] markers = map.GetComponentsInChildren<Marker> ();
		foreach (Marker marker in markers) {
			if (marker.CoordinatesWGS84 [0] == latitude && marker.CoordinatesWGS84 [1] == longitude) {
				map.RemoveMarker (marker);
				SetNullLastPutMarkerCoordinates ();
			}
		}
	}

	public void SetNullLastPutMarkerCoordinates ()
	{
		LastPutMarkerCoordinates = null;
	}

	private InputGenerator GetValidInputGenerator()
	{
		#if UNITY_EDITOR
		return GetComponent<EditorInputGenerator>();
		#else
		return GetComponent<DeviceInputGenerator>();
		#endif
	}

	public void SetSingleMarkerOnMap ()
	{
		if (LastPutMarkerCoordinates != null) {
			RemoveLastPutMarker ();
			
		}
		SetMarkerInMap ();
	}

	public void SetMarkerInMap ()
	{	
		Dictionary<string, double> CursorCoordinates = GetCoordinatesOfCursor ();
		CreateAnnotation (CursorCoordinates ["latitude"], CursorCoordinates ["longitude"]);
		SetCoordinatesOnInputField (CursorCoordinates ["latitude"], CursorCoordinates ["longitude"]);
		LastPutMarkerCoordinates = CursorCoordinates;

	}

	public Dictionary<string, double> GetCoordinatesOfCursor ()
	{
		Dictionary<string, double> dictionary = new Dictionary<string, double> ();
		
		Vector3 wordPos = getCursorPosition ();
		
		//ReportTrigger.transform.localScale = new Vector2 (0.5f,0.5f);
		double latitude = (0.0167 * wordPos [2]) + ((map.CenterWGS84) [1]);
		double longitude = (0.0167 * wordPos [0]) + ((map.CenterWGS84) [0]);
		dictionary.Add ("latitude", latitude);
		dictionary.Add ("longitude", longitude);
		return dictionary;
		
	}

	public Vector3 getCursorPosition ()
	{
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		ReportTrigger.transform.position = mousePos;
		Ray ray = Camera.main.ScreenPointToRay (mousePos);
		RaycastHit hit;
		
		Vector3 wordPos;
		if (Physics.Raycast (ray, out hit, 1000f)) {
			
			wordPos = hit.point;
			
		} else {
			
			wordPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
		}
		
		return wordPos;
	}

	public void SetCoordinatesOnInputField (double latitude, double longitude)
	{
		DirectionInputField.text = latitude.ToString () + " , " + longitude.ToString ();
	}
}
