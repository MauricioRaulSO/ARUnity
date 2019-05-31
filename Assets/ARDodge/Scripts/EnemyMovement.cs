using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Velocity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody me = gameObject.GetComponent<Rigidbody>();
        me.AddForce(-transform.forward * Velocity);
        me.AddTorque(new Vector3(Random.value, Random.value, Random.value));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
