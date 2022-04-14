using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCollisionDetection : MonoBehaviour
{
    public Collider2D[] _allColliders;

    private void Start()
    {
        _allColliders = transform.GetComponentsInChildren<Collider2D>();
    }
}
