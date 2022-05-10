using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DaimnonPhysicsMaterial { Concrete, Rubber, Trampoline }

public class DaimnonPysicsMaterial : MonoBehaviour
{
    [SerializeField]
    private float _friction = 0f, _bounciness = 0f;

    [SerializeField]
    private Collider2D _collider;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void ApplyPhysicsMaterial(DaimnonPhysicsMaterial type)
    {

    }
}
