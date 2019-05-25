using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARTrackedImageInfoManager : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The camera to set the WorldSPace UI canvas.")]
	Camera m_WorldSpaceCanvasCamera;

	public Camera worldSpaceCanvasCamera {
		get { return m_WorldSpaceCanvasCamera; }
		set { m_WorldSpaceCanvasCamera = value; }
	}

	[SerializeField]
	[Tooltip("If an image is detected bout no source texture, show this instead.")]
	Texture2D m_DefaultTexture;

	public Texture2D defaultTexture {
		get { return m_DefaultTexture; }
		set { m_DefaultTexture = value; }
	}

	ARTrackedImageManager m_TrackedImageManager;

	private void Awake() {
		m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
	}

	private void OnEnable() {
		m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
	}

	void UpdateInfo(ARTrackedImage trackedImage) {
		Canvas canvas = trackedImage.GetComponentInChildren<Canvas>();
		if (canvas) canvas.worldCamera = worldSpaceCanvasCamera;
		if (trackedImage.trackingState != TrackingState.None) {
			trackedImage.gameObject.SetActive(true);
			trackedImage.transform.localScale = new Vector3(trackedImage.size.x, 1.0F, trackedImage.size.y);
		} else {
			trackedImage.gameObject.SetActive(false);
		}
	}

	void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {
		foreach (var trackedImage in eventArgs.added) {
			trackedImage.transform.localScale = new Vector3(0.01F, 1.0F, 0.01F);
			UpdateInfo(trackedImage);
		}
		foreach (var trackedImage in eventArgs.updated) {
			UpdateInfo(trackedImage);
		}
	}
}
