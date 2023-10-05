using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _cooldownAttack = 2;

    private float _timeAfterAttack = 0;
    private int _damage;

    public event UnityAction ReadyContinueMoving;

    public void OnTryAttack(Player player)
    {
        if (_timeAfterAttack <= 0)
        {
            player.ApplyDamage(_damage);

            _timeAfterAttack = _cooldownAttack;

            StartCoroutine(Reload());
        }
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private IEnumerator Reload()
    {
        while (_timeAfterAttack > 0)
        {
            _timeAfterAttack -= Time.deltaTime;
            yield return null;
        }

        ReadyContinueMoving?.Invoke();
    }
}
