using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private List<Item> _items;

    private Player _target;

    public event UnityAction<int, int> ChangedHealth;

    public int Damage => _damage;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        ChangedHealth?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            GiveItem();
            gameObject.SetActive(false);
        }
    }

    private void GiveItem()
    {
        int minValue = 0;
        int maxVlue = _items.Count - 1;

        Item randomItem = _items[Random.Range(minValue, maxVlue)];

        Instantiate(randomItem, transform.position, Quaternion.identity);
    }
}