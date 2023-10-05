using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    public event UnityAction<int, int> ChangedHealth;

    public int CurrentHealth => _currentHealth;

    public void Shoot()
    {
        _weapon.Shoot();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        ChangedHealth?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void SetCurrentHealth(int health)
    {
      _currentHealth = health;
      ChangedHealth?.Invoke(_currentHealth, _maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Item>(out Item item))
        {
            _inventory.AddItem(item);
            Destroy(other.gameObject);
        }
    }
}