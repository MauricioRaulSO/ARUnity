using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceInGroundAt : MonoBehaviour 
{
	public Vector2 XZposition;
	public bool isUpdating;

	private ARRaycastManager arRaycastManager;
	private ARSessionOrigin arOrigin;
	private Pose placementPose;
	private bool placementPoseIsValid = false;

	void Start() {
		arOrigin = FindObjectOfType<ARSessionOrigin>();
		arRaycastManager = FindObjectOfType<ARRaycastManager>();
	}

	void Update() {
		UpdatePlacementPose();
		UpdatePlacementIndicator();
	}

	private void UpdatePlacementIndicator() {
		if (placementPoseIsValid && isUpdating) {
			transform.position = new Vector3(XZposition.x, placementPose.position.y, XZposition.y);
		} else {
		}
	}

	private void UpdatePlacementPose() {
		Vector2 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5F, 0.5F));
		List<ARRaycastHit> hits = new List<ARRaycastHit>();
		arRaycastManager.Raycast(screenCenter, hits, TrackableType.All);

		placementPoseIsValid = hits.Count > 0;
		if (placementPoseIsValid) {
			placementPose = hits[0].pose;
		}
	}
}
