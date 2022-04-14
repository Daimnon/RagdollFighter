using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image _hpFill;

    [SerializeField]
    private int _maxHp = 100;

    public bool IsColliding = false;

    public float CurrentHp, Dmg = 1f;

    private void Awake()
    {

        CurrentHp = _maxHp;
        _hpFill.fillAmount = 1;
    }

    private void Update()
    {
        _hpFill.fillAmount = CurrentHp / 100;
    }

    private void LateUpdate()
    {
        //IsColliding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && gameObject.name == "Player1")
            IsColliding = true;

        if (collision.gameObject.layer == 8 && gameObject.name == "Player2")
            IsColliding = true;
    }
}
