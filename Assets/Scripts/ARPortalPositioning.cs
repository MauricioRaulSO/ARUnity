using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPortalPositioning : MonoBehaviour
{
    public GameObject arPortal;
    public Vector3 portalDirectction = Vector3.forward;
    public float portalDistance = 2.0F;

    private void Update()
    {
        SetPortal();
    }

    void SetPortal()
    {
        arPortal.transform.position = Camera.current.transform.position;
        arPortal.transform.position += portalDirectction.normalized * portalDistance;
        arPortal.transform.rotation = Quaternion.LookRotation(portalDirectction.normalized, Vector3.up);
    }
}
