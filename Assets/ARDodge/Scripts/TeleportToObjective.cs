using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToObjective : MonoBehaviour
{
    public Transform objective;
    private void Update()
    {
        transform.position = objective.position;
    }
}
