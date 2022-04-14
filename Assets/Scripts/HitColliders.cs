using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColliders : MonoBehaviour
{
    [SerializeField]
    private SelfCollisionDetection _selfCollisionDetector;
    
    private Transform _currentPlayer;

    private Rigidbody2D _currentRb;

    private PlayerStats _playerStats;

    private float _timeCounter = 0;

    private bool _isSlowingTime;

    private void Start()
    {
        _currentRb = GetComponent<Rigidbody2D>();
        _playerStats = transform.root.GetComponent<PlayerStats>();
        _currentPlayer = transform.root;
    }

    private void Update()
    {
        TimeSlow();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D collisionRb = collision.collider.GetComponent<Rigidbody2D>();

        //check for touching other player
        if (collision.transform.root != _currentPlayer && collision.collider.transform.tag == "Player")
        {
            if (_selfCollisionDetector._allColliders.Contains(collision.collider))
                return;

            else
            {
                collisionRb = collision.collider.GetComponent<Rigidbody2D>();
                collisionRb.AddForce(_currentRb.velocity, ForceMode2D.Impulse);

                PlayerStats enemyStats = collision.transform.root.GetComponent<PlayerStats>();
                enemyStats.CurrentHp -= _playerStats.Dmg;
            }
        }

        //check for touching other hit collider
        if (collision.transform.root != _currentPlayer && collision.gameObject.layer == 10)
        {
            _currentRb.AddForce(-_currentRb.velocity, ForceMode2D.Impulse);

            _isSlowingTime = true;
            //play effects


        }   
    }

    private void TimeSlow()
    {
        if (_isSlowingTime)
        {
            Time.timeScale = 0.5f;
            _timeCounter += Time.deltaTime;
        }

        if (_timeCounter >= 1.25f)
        {
            Time.timeScale = 1f;
            _timeCounter = 0;
            _isSlowingTime = false;
        }
    }
}
