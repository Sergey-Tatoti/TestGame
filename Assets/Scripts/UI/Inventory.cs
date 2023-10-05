using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemView _templateItem;
    [SerializeField] private GameObject _itemViewConteiner;
    [SerializeField] private GameObject _itemConteiner;
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<ItemView> _itemViews;

    public void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            CreateItem(_items[i]);
        }
    }

    public void AddItem(Item item)
    {
        Item newItem;

        if (MatchItem(item) == false)
        {
            newItem = Instantiate(item, _itemConteiner.transform);
            _items.Add(newItem);
            CreateItem(newItem);
        }
    }

    private void CreateItem(Item item)
    {
        var view = Instantiate(_templateItem, _itemViewConteiner.transform);
        _itemViews.Add(view);

        view.Render(item);
        view.DeletedItem += OnDeletedItem;
    }

    private void UpdateInventory(Item item)
    {
        for (int i = 0; i < _itemViews.Count; i++)
        {
            if (_itemViews[i].Id == item.Id)
                _itemViews[i].UpdateCount(item.Count);
        }
    }

    private bool MatchItem(Item item)
    {
        bool isMatch = false;

        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Id == item.Id)
            {
                _items[i].AddCount(item.Count);
                UpdateInventory(_items[i]);
                isMatch = true;
            }
        }

        return isMatch;
    }

    private void OnDeletedItem(ItemView itemView)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (itemView.Id == _items[i].Id)
                Destroy(_items[i].gameObject);
        }
    }
}
