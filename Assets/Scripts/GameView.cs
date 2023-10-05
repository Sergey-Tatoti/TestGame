using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button _shutButton;
    [SerializeField] private Button _invenoryButton;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _inventoryPanel;

    private void OnEnable() 
    {
        _shutButton.onClick.AddListener(_player.Shoot);
        _invenoryButton.onClick.AddListener(ShowInventory);
    }

    private void OnDisable() 
    {
        _shutButton.onClick.RemoveListener(_player.Shoot);
        _invenoryButton.onClick.RemoveListener(ShowInventory);
    }

    private void ShowInventory()
    {
        if(_inventoryPanel.activeSelf == true)
        _inventoryPanel.SetActive(false);
        else
        _inventoryPanel.SetActive(true);
    }
}
