using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{
    [SerializeField] private int _countBullets;

    private float _timeAfterShoot = 0;

    private void Start() 
    {
        ChangedCountBullet?.Invoke(_countBullets);
    }

    public override void Shoot()
    {
        if (_timeAfterShoot <= 0)
        {
            Instantiate(_bullet, transform.position, SetDirectionBullet());

            _countBullets--;
            ChangedCountBullet?.Invoke(_countBullets);
            
            _timeAfterShoot = TimeReload;

            if(_countBullets > 0)
            StartCoroutine(Reload());
        }
    }

    public override IEnumerator Reload()
    {
        while (_timeAfterShoot > 0)
        {
            _timeAfterShoot -= Time.deltaTime;
            yield return null;
        }
    }

    private Quaternion SetDirectionBullet()
    {
        Quaternion rotateBullet;
        int FlipBullet = 180;

        if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            rotateBullet = Quaternion.identity;
        else
            rotateBullet = Quaternion.Euler(0, transform.eulerAngles.y + FlipBullet, 0);

        return rotateBullet;

    }
}
