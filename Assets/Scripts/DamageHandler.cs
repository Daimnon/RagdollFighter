using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _player1Stats, _player2Stats;

    [SerializeField]
    private float _hitDamage = 20f;

    private void Update()
    {
        if (_player1Stats.IsColliding)
            _player1Stats.CurrentHp -= _hitDamage;

        if (_player2Stats.IsColliding)
            _player2Stats.CurrentHp -= _hitDamage;
    }
}
