using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<BodyPart> _bodyParts;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceAttack = 0.5f;

    private Player _player;
    private bool _canMove = false;

    public event UnityAction<Player> ZoneAttacked;

    private void Update()
    {
        if (_canMove == true && _player != null)
        {
            Move();

            if (transform.position.x > _player.transform.position.x)
            ChangeDirectionPlayer(true);

            if (transform.position.x < _player.transform.position.x)
            ChangeDirectionPlayer(false);
        }

        if (_player != null)
            TryAttack();
    }

    public void SetTarget(Player player)
    {
        _canMove = true;
        _player = player;
    }

    public void OnContinueMoving()
    {
        _canMove = true;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    private void TryAttack()
    {
        float _distance = Vector2.Distance(transform.position, _player.transform.position);

        if (_distance < _distanceAttack)
        {
            ZoneAttacked?.Invoke(_player);

            _canMove = false;
        }
    }

    private void ChangeDirectionPlayer(bool isLeft)
    {
        for (int i = 0; i < _bodyParts.Count; i++)
        {
            _bodyParts[i].FlipBody(isLeft);
        }
    }
}