using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTargetFramerate : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Sets the application's target frame rate")]
	int m_TargetFrameRate = 60;

	private void Start() {
		SetFrameRate();
	}

	public int targetFrameRate {
		get { return m_TargetFrameRate; }
		set {
			m_TargetFrameRate = value;
			SetFrameRate();
		}
	}

	void SetFrameRate() {
		Application.targetFrameRate = targetFrameRate;
	}
}
