using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMAdjuster : MonoBehaviour
{
    public Rigidbody body;
    public Vector3 centerOfMassOffset;

    private void Awake()
    {
        body.centerOfMass += centerOfMassOffset;
    }
}
