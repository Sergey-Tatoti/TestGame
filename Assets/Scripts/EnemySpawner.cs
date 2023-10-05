using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _emenies;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;

    private void Start() 
    {
        for (int i = 0; i < _emenies.Count; i++)
        {
            _emenies[i].transform.position = new Vector2 (Random.Range(_minPositionX, _maxPositionX), Random.Range(_minPositionY, _maxPositionY));
            _emenies[i].gameObject.SetActive(true);
        }
    }
}
