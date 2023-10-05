using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoombie : Enemy
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private EnemyAttack _enemyAttack;

    private void OnEnable()
    {
        _enemyMovement.ZoneAttacked += _enemyAttack.OnTryAttack;
        _enemyAttack.ReadyContinueMoving += _enemyMovement.OnContinueMoving;
    }

    private void OnDisable()
    {
        _enemyMovement.ZoneAttacked -= _enemyAttack.OnTryAttack;
        _enemyAttack.ReadyContinueMoving -= _enemyMovement.OnContinueMoving;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _enemyMovement.SetTarget(player);
            _enemyAttack.SetDamage(Damage);
        }
    }
}
