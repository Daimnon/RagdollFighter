using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private OriginalRigidbody _playerOriginalRb;
    [SerializeField] private int _moveSpeed = 1;

    private float _xInput, _yInput;
    private Vector2 _moveVector;
    
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void GetInput()
    {
        _xInput = Input.GetAxis("Player1H");
        _yInput = Input.GetAxis("Player1V");
        _moveVector = new Vector2(_xInput, _yInput);
    }

    private void MoveCharacter()
    {
        _playerOriginalRb.AddForce(_moveVector * (_moveSpeed * Time.fixedDeltaTime), OriginalForceMode.Force);
        //_playerRb.AddForce(_moveVector * (_moveSpeed * Time.fixedDeltaTime), ForceMode2D.Force);
    }
}