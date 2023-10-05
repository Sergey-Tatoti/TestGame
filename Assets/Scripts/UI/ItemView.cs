using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _itemButton;
    [SerializeField] private int _id;

    public event UnityAction<ItemView> DeletedItem;

    public int Id => _id;

    private void OnEnable()
    {
        _itemButton.onClick.AddListener(ShowDeleteButton);
        _deleteButton.onClick.AddListener(DeleteItem);
    }

    private void OnDisable()
    {
        _itemButton.onClick.RemoveListener(ShowDeleteButton);
        _deleteButton.onClick.RemoveListener(DeleteItem);
    }

    public void Render(Item item)
    {
        _icon.sprite = item.Icon;
        _id = item.Id;
        _count.text = null;

        if (item.Count > 1)
            _count.text = item.Count.ToString();
    }

    public void UpdateCount(int count)
    {
        _count.text = null;

        if (count > 1)
            _count.text = count.ToString();
    }

    private void ShowDeleteButton()
    {
        if (_deleteButton.gameObject.activeSelf == true)
            _deleteButton.gameObject.SetActive(false);
        else
            _deleteButton.gameObject.SetActive(true);
    }

    private void DeleteItem()
    {
        Destroy(gameObject);

        DeletedItem?.Invoke(this);
    }
}
