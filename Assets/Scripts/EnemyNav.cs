using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNav : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _enemyRb, _playerRb;

    [SerializeField]
    private float _smoothing = 1.75f, _moveSpeed = 5000f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_playerRb.position.x == _enemyRb.position.x)
            return;
        else if (_playerRb.position.x < _enemyRb.position.x)
        _enemyRb.AddForce(_playerRb.transform.up * (_moveSpeed * Time.fixedDeltaTime), ForceMode2D.Force);
        else
            _enemyRb.AddForce(-_playerRb.transform.up * (_moveSpeed * Time.fixedDeltaTime), ForceMode2D.Force);

        if (_playerRb.position.y == _enemyRb.position.y)
            return;
        else if (_playerRb.position.y < _enemyRb.position.y)
            _enemyRb.AddForce(-_playerRb.transform.right * (_moveSpeed * Time.fixedDeltaTime), ForceMode2D.Force);
        else
            _enemyRb.AddForce(_playerRb.transform.right * (_moveSpeed * Time.fixedDeltaTime), ForceMode2D.Force);
    }
}
