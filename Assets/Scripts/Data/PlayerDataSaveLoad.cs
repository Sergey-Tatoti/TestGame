using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSaveLoad : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void SavePlayer()
    {
      BinarySavingSystem.PlayerSave(_player);
    }

    public void LoadPlayer()
    {
      PlayerData data = BinarySavingSystem.LoadPlayer();

      _player.SetCurrentHealth(data.Health);
    }
}
