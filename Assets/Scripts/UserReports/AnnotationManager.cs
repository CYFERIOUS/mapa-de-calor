using UnityEngine;
using System.Collections;

public class AnnotationManager {

	private IFormDataLoader loader;
	public MapWrapper mapWrapper;
	private ArrayList reports;

	public AnnotationManager (IFormDataLoader _loader, MapWrapper _mapWrapper) {
		loader = _loader;
		reports = new ArrayList();
		mapWrapper = _mapWrapper;
	}

	public ArrayList getReports() {
		int totals = loader.GetTotalKey();
		reports = new ArrayList();
		for(int id = 0; id < totals; ++id)
			reports.Add(loader.Load (id));
		return reports;
	}
	
	public void loadAnnotations () {
		getReports();
		foreach (FormData report in reports)
			mapWrapper.SetMarkerInMap(new Coordinates(report.annotation.x, report.annotation.y));
	}

	public int AnnotationsCount () {
		return reports.Count;
	}
}