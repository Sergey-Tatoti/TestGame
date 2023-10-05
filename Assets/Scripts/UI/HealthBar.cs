using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        if(_player != null)
        _player.ChangedHealth += OnValueChanged;

        if(_enemy != null)
        _enemy.ChangedHealth += OnValueChanged;
        
        Slider.value = 1;
    }

    private void OnDisable()
    {
        if(_player != null)
        _player.ChangedHealth -= OnValueChanged;

        if(_enemy != null)
        _enemy.ChangedHealth -= OnValueChanged;
    }
}
