using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fix Balancing in Editor

public class Balance : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float _targetRotation, _force;

    void Update()
    {
        _rb.MoveRotation(Mathf.LerpAngle(_rb.rotation, _targetRotation, _force * Time.fixedDeltaTime));
    }
}
