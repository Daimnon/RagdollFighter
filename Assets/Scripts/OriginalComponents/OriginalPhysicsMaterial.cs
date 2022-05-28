using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalPhysicsMaterial : MonoBehaviour
{
    //[SerializeField] private Collider2D _collider;
    [SerializeField] private float _forceModifier;

    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
        GameObject gameObject;
        
        if (collision.collider.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            gameObject = collision.gameObject;
            OriginalRigidbody gameObjectRB = gameObject.GetComponent<OriginalRigidbody>();
            Bounce(gameObjectRB, _forceModifier, (Vector2)collision.GetContact(0).point);
        }
        else
            return;
    }

    private void Bounce(OriginalRigidbody gameObjectRB, float forceMultiplier, Vector2 contactPoint)
    {
        Collider2D gameObjectCollider = gameObjectRB.GetComponent<Collider2D>();
        Vector2 gameObjectCenterPos = gameObjectCollider.bounds.center;
        Vector2 gameObjectInvertedVelocity = -gameObjectRB.Velocity;
        Vector2 gameObjectNormal = ((Vector2)transform.position - contactPoint).normalized;

        float angle = Vector3.Angle(gameObjectInvertedVelocity, gameObjectNormal);

        Vector3 cross = Vector3.Cross(gameObjectInvertedVelocity, gameObjectNormal);

        if (cross.z < 0)
        {
            angle = -angle;
        }

        gameObjectInvertedVelocity = Quaternion.Euler(0, 0, angle * 2) * gameObjectInvertedVelocity;
        gameObjectRB.Velocity = gameObjectInvertedVelocity;


        //Vector2 knockbackVelocity = new Vector2((transform.position.x - gameObjectRB.transform.position.x) * forceMultiplier, (transform.position.y - //gameObjectRB.transform.position.y) * forceMultiplier);
        //gameObjectRB.GetComponent<Rigidbody2D>().velocity = -knockbackVelocity;
        //
        //print($"{gameObjectRB.name} was bounce by a force of {knockbackVelocity} added in the oposite direction of the current movement velocity");
    }
}
