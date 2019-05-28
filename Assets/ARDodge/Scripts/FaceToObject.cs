using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToObject : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target)
        {
            Vector3 direction = transform.position - target.transform.position;
            transform.localRotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}
