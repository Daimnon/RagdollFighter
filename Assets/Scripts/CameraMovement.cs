using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCam;

    [SerializeField]
    private Rigidbody2D _player1Rb, _player2Rb;

    [SerializeField]
    private BoxCollider2D _levelBoundries;

    private Vector3 _minBounds, _maxBounds;

    [SerializeField]
    private float _moveSmoothing = 1.75f, _zoomSmoothing = 1.75f, _minCamZoom, _maxCamZoom;

    private float _camHalfWidth, _camHalfHeight;

    private Vector3 _targetPos;

    private void Awake()
    {
        _minBounds = _levelBoundries.bounds.min;
        _maxBounds = _levelBoundries.bounds.max;
    }

    private void Update()
    {
        BoundCameraToMap();
    }

    void FixedUpdate()
    {
        ScaleCameraSize();
        transform.position = Vector3.Lerp(transform.position, GetTargetPos(), _moveSmoothing * Time.fixedDeltaTime);
    }

    private Vector3 GetTargetPos()
    {
        _targetPos = (_player1Rb.position + _player2Rb.position);
        _targetPos.z = transform.position.z;


        return _targetPos;
    }

    private void ScaleCameraSize()
    {
        float greaterDistance;
        greaterDistance = (_player1Rb.transform.position - _player2Rb.transform.position).magnitude;
        greaterDistance = Mathf.Clamp(greaterDistance * 2 / 5, _minCamZoom, _maxCamZoom);

        _mainCam.orthographicSize = Mathf.Lerp(_mainCam.orthographicSize, greaterDistance, _zoomSmoothing * Time.fixedDeltaTime);
    }

    private void BoundCameraToMap()
    {
        _camHalfHeight = _mainCam.orthographicSize;
        _camHalfWidth = _camHalfHeight * Screen.width / Screen.height;

        float clampedCamWidth = Mathf.Clamp(transform.position.x, _minBounds.x + _camHalfWidth, _maxBounds.x - _camHalfWidth);
        float clampedCamHeight = Mathf.Clamp(transform.position.y, _minBounds.y + _camHalfHeight, _maxBounds.y - _camHalfHeight);

        transform.position = new Vector3(clampedCamWidth, clampedCamHeight, transform.position.z);
    }
}
