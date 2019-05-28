using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOnCollision : MonoBehaviour
{
    public UnityEvent OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision.Invoke();
    }
}
