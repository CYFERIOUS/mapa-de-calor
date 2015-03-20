using UnityEngine;
using UnitySlippyMap;
using UnityEngine.UI;

public class MapWrapperBehaviour:MonoBehaviour
{
	public Texture	LocationTexture;
	public Texture	MarkerTexture;
	public GameObject ReportTrigger;
	public InputField DirectionInputField;

	protected InputReader inputReader;
	protected double PrivateTriggerMovementManagerXAxis;
	protected double PrivateTriggerMovementManagerYAxis;
	protected bool isOnMainWindow = true;

	private MapWrapper mapWrapper;
	private AbstractMap mapImplementation;
	private MarkerGenerator markerGenerator;
	private IFormDataLoader loader;
	private AnnotationManager manager;

	[SerializeField]
	private ReportView reportView;

	void Start ()
	{	

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
		PrivateTriggerMovementManagerXAxis = mapWrapper.GetReferenceLocation().Longitude;
		PrivateTriggerMovementManagerYAxis = mapWrapper.GetReferenceLocation().Latitude;

			
		
	}

	public void AddTemporalMarker ()
	{
		mapWrapper.AddTemporalMarker ();
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

		float restaX = Mathf.Abs ((float)PrivateTriggerMovementManagerXAxis - (float)mapWrapper.GetReferenceLocation().Longitude);
		float restaY = Mathf.Abs ((float)PrivateTriggerMovementManagerYAxis - (float)mapWrapper.GetReferenceLocation().Latitude);
		
		if ( (restaX>0.001 || restaY>0.001) && ReportTrigger.activeInHierarchy == true) {
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
		inputReader.TapExecuted += HandleTap;
		inputReader.LongPressExecuted += HandleLongPress;
	}

	private void HandleLongPress(){

			SetSingleMarkerOnMap();
			ReportTrigger.SetActive (true);
			PrivateTriggerMovementManagerXAxis = mapWrapper.GetReferenceLocation().Longitude;
			PrivateTriggerMovementManagerYAxis = mapWrapper.GetReferenceLocation().Latitude;
		
	}

	private void HandleTap(){


			getObjectType ();

		
	}

	
	public void RemoveLastPutMarker ()
	{
		mapWrapper.RemoveTemporalMarker ();
	}
	

	public void EraseTemporalMarker ()
	{
		mapWrapper.RemoveTemporalMarker();
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
		Coordinates location = GetCoordinatesOfCursor ();
		mapWrapper.SetTemporalMarker (location);
		SetCoordinatesOnInputField (location.Latitude, location.Longitude);
	}

	public Coordinates GetCoordinatesOfCursor ()
	{
		Coordinates referenceLocation = mapWrapper.GetReferenceLocation () as Coordinates;
		Vector3 wordPos = getCursorPosition ();
		double latitude = (0.0167 * wordPos [2]) + (referenceLocation.Latitude);
		double longitude = (0.0167 * wordPos [0]) + (referenceLocation.Longitude);
		return new Coordinates (latitude, longitude); 
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

	public void getObjectType ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if(hit.collider.gameObject.tag == "Pin"){
				reportView.gameObject.SetActive(true);
			}
		} else {
			hit.collider.gameObject.SetActive(true);
		}
	}

	public void SetCoordinatesOnInputField (double latitude, double longitude)
	{
		DirectionInputField.text = latitude.ToString () + " , " + longitude.ToString ();
	}

	public void ToggleisOnMainWindow(){
		isOnMainWindow = !isOnMainWindow;
	}
	
	public void SetToTrueIsOnMainWindow(){
		isOnMainWindow = true;
	}
}
