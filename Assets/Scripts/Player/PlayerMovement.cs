using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private List<BodyPart> _bodyParts;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();

        if (_fixedJoystick.Horizontal < 0)
            ChangeDirectionPlayer(true);

        if (_fixedJoystick.Horizontal > 0)
            ChangeDirectionPlayer(false);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_fixedJoystick.Horizontal * _speed * Time.fixedDeltaTime, _fixedJoystick.Vertical * _speed * Time.fixedDeltaTime);
    }

    private void ChangeDirectionPlayer(bool isLeft)
    {
        for (int i = 0; i < _bodyParts.Count; i++)
        {
            _bodyParts[i].FlipBody(isLeft);
        }
    }
}