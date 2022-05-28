using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OriginalForceMode { Force, Acceleration, Impulse, VelocityChange }

public class OriginalRigidbody : MonoBehaviour
{
    #region Serialized Fields
    [Header("SerializedFields")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Collider2D _collider;

    // will affect peformance
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private float _accelerationSmoothing;
    #endregion

    #region Serialized Backing Fields
    [Header("Properties")]
    [SerializeField] Vector2 _velocity;
    [SerializeField] Vector2 _normal;
    [SerializeField] float _mass, _drag;

    [Header("Conditions")]
    [SerializeField] bool _isGrounded;
    [SerializeField] bool _useGravity, _isKinematic;

    [Header("Freeze Axis")]
    [SerializeField] bool _freezPositionX;
    [SerializeField] bool _freezPositionY, _freezPositionZ, _freezRotationX, _freezRotationY, _freezRotationZ;
    #endregion

    #region Private Fields
    //Vector3 _gravityScale;
    #endregion

    #region Properties
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }
    public Vector2 Normal { get => GetNormal(); set => _normal = value; }
    public float Mass { get => _mass; set => _mass = value; }
    public float Drag { get => _drag; set => _drag = value; }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public bool UseGravity { get => _useGravity; set => _useGravity = value; }
    public bool IsKinematic { get => _isKinematic; set => _isKinematic = value; }
    public bool FreezPositionX { get => _freezPositionX; set => _freezPositionX = value; }
    public bool FreezPositionY { get => _freezPositionY; set => _freezPositionY = value; }
    public bool FreezPositionZ { get => _freezPositionZ; set => _freezPositionZ = value; }
    public bool FreezRotationX { get => _freezRotationX; set => _freezRotationX = value; }
    public bool FreezRotationY { get => _freezRotationY; set => _freezRotationY = value; }
    public bool FreezRotationZ { get => _freezRotationZ; set => _freezRotationZ = value; }
    #endregion


    bool testAddForce = false;
    public void Start()
    {
        _useGravity = true;
        _isKinematic = false;
        _freezPositionX = false;
        _freezPositionY = false;
        _freezPositionZ = false;
        _freezRotationX = false;
        _freezRotationY = false;
        _freezRotationZ = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            testAddForce = true;
        }
    }

    private void FixedUpdate()
    {
        if (testAddForce)
        {
            AddForce(new Vector2(1, 0), OriginalForceMode.Force);
            testAddForce = false;
        }

        ApplyGravity();
        UpdateKinematic();
        UpdateFreezings();
        transform.position += (Vector3)Velocity;
    }

    #region Private Methods
    private void CalculateVelocity()
    {
        
    }
    
    private void UpdateKinematic()
    {
        if (_isKinematic)
            _useGravity = false;
        else if (!_isKinematic)
            _useGravity = true;
    }

    private void UpdateFreezings()
    {
        if (!_freezPositionX)
            return;
        else
            transform.localPosition = new Vector3(0f, transform.position.y, transform.position.z);

        if (!_freezPositionY)
            return;
        else
            transform.localPosition = new Vector3(transform.position.x, 0f, transform.position.z);

        if (!_freezPositionZ)
            return;
        else
            transform.localPosition = new Vector3(transform.position.z, transform.position.y, 0f);

        if (!_freezRotationX)
            return;
        else
            transform.localRotation = new Quaternion(0f, Quaternion.identity.y, Quaternion.identity.z, Quaternion.identity.w);

        if (!_freezRotationY)
            return;
        else
            transform.localRotation = new Quaternion(Quaternion.identity.x, 0f, Quaternion.identity.z, Quaternion.identity.w);

        if (!_freezRotationZ)
            return;
        else
            transform.localRotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, 0f, Quaternion.identity.w);
    }

    private void ApplyGravity()
    {
        if (_useGravity && !_isGrounded)
            _velocity += Physics2D.gravity * _gravityModifier * Time.fixedDeltaTime;
        else
            return;
    }

    private Vector2 GetNormal()
    {
        Vector2 normal;

        normal = _velocity.normalized;
        return normal;
    }
    #endregion

    #region Public Methods
    public void AddForce(Vector2 force, OriginalForceMode forceMode)
    {
        switch (forceMode)
        {
            case OriginalForceMode.Force:
                _velocity += force;
                break;
            //case OriginalForceMode.Acceleration:
            //    Vector3.Lerp(transform.position, force, _accelerationSmoothing);
            //    break;
            //case OriginalForceMode.Impulse:
            //    break;
            //case OriginalForceMode.VelocityChange:
            //    break;
            default:
                break;
        }
        
    }

    public void MovePosition(Vector3 newPosition)
    {
        transform.Translate(newPosition);
    }

    public bool CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, _groundLayer))
        {
            _isGrounded = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Hit Ground");
        }
        else
        {
            _isGrounded = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Didn't Hit Ground");
        }

        return _isGrounded;
    }

    public void ApplyConstantForce(Vector3 vector3, float amount)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
