using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPortalPositioning : MonoBehaviour
{
    public GameObject portalPrefab;
    public GameObject arPortal;
    public Vector3 portalDirectction = Vector3.forward;
    public float portalDistance = 2.0F;

    private void Update()
    {
        UpdatePortalPosition();
    }

    private void Start()
    {
        CreatePortal();
    }

    public void StartPortal()
    {
        arPortal.GetComponent<EnemySpawner>().Starter();
    }

    public void DeletePortal()
    {
        Destroy(arPortal);
    }

    public void CreatePortal()
    {
        Debug.Log("Create Portal");
        if (arPortal)
        {
            DeletePortal();
        }
        arPortal = Instantiate(portalPrefab);
        UpdatePortalPosition();
    }

    private void UpdatePortalPosition()
    {
        Debug.Log("UpdatePortalPosition");
        if (arPortal == null) return;
        if (Camera.current == null) return;

        arPortal.transform.position = Camera.current.transform.position;
        arPortal.transform.position += portalDirectction.normalized * portalDistance;
        arPortal.transform.rotation = Quaternion.LookRotation(portalDirectction.normalized, Vector3.up);
    }
}
