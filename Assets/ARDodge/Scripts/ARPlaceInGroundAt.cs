using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Events;

public class ARPlaceInGroundAt : MonoBehaviour 
{
    public GameObject worldCanvas;
    public GameObject player;
	public Vector2 XZposition;
	public bool isUpdating;
    public Gradient Colors;
    public UnityEvent OnOutsideDelimiter;
    public UnityEvent OnInsideDelimiter;

    private ARRaycastManager arRaycastManager;
	private ARSessionOrigin arOrigin;
    private Renderer meshRenderer;
    private Pose placementPose;
	private bool placementPoseIsValid = false;

	void Start() {
		arOrigin = FindObjectOfType<ARSessionOrigin>();
		arRaycastManager = FindObjectOfType<ARRaycastManager>();
        meshRenderer = GetComponent<Renderer>();
        meshRenderer.material = new Material(meshRenderer.material);
    }

    private void Update()
    {
        float distance = Vector2.Distance(
                new Vector2(player.transform.position.x, player.transform.position.z),
                new Vector2(transform.position.x, transform.position.z)
            ) * 2 / transform.localScale.x;
        meshRenderer.material.color = Colors.Evaluate( distance );
        if (distance > 1.0F)
        {
            OnOutsideDelimiter.Invoke();
        } else
        {
            OnInsideDelimiter.Invoke();
        }
    }

    public void UpdatePosition() {
		UpdatePlacementPose();
		UpdatePlacementIndicator();
	}

	private void UpdatePlacementIndicator() {
		if (placementPoseIsValid && isUpdating) {
            XZposition = new Vector2(placementPose.position.x, placementPose.position.z);
			transform.position = new Vector3(XZposition.x, placementPose.position.y, XZposition.y);
            worldCanvas.transform.position = new Vector3(XZposition.x, 0.0F, XZposition.y);
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
