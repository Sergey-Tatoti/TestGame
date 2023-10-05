using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _bullet;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _timeReload;

    public UnityAction<int> ChangedCountBullet;
    
    public Sprite Icon => _icon;
    public float TimeReload => _timeReload;

    public abstract void Shoot();
    public abstract IEnumerator Reload();
}
