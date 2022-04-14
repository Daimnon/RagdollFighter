using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Apply movement & fix Ragdoll IK & Hinges?

public class Player2Controller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRb;

    [SerializeField]
    private int _moveSpeed = 5000;

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
        _xInput = Input.GetAxis("Player2H");
        _yInput = Input.GetAxis("Player2V");
        _moveVector = new Vector2(_xInput, _yInput);
    }

    private void MoveCharacter()
    {
        _playerRb.AddForce(_moveVector * (_moveSpeed * Time.fixedDeltaTime), ForceMode2D.Force);
        //print($"adding force: [{_moveVector}]");
    }
}
