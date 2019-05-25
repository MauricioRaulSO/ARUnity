using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody me = gameObject.GetComponent<Rigidbody>();
        me.AddForce(Vector3.back * vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
