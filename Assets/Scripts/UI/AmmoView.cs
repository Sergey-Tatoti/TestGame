using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TMP_Text _countAmmo;

    private void OnEnable() 
    {
        _weapon.ChangedCountBullet += ChangeCount;
    }

    private void OnDisable() 
    {
        _weapon.ChangedCountBullet -= ChangeCount;
    }

    private void ChangeCount(int countAmmo)
    {
        _countAmmo.text = countAmmo.ToString();
    }
}
