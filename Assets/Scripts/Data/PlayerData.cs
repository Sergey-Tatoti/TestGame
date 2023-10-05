using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int Health;

    public PlayerData(Player player)
    {
        Health = player.CurrentHealth;
    }

}
