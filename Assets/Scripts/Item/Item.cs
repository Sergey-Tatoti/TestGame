using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _count;
    [SerializeField] private Sprite _icon;

    public int Count => _count;
    public int Id => _id;
    public Sprite Icon => _icon;

    public void AddCount(int count)
    {
        _count += count;
    }

}
