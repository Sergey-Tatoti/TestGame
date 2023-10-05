using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySavingSystem
{
  public static void PlayerSave(Player player)
  {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/playerSave";
    FileStream stream = new FileStream(path, FileMode.Create);

    PlayerData data = new PlayerData(player);

    formatter.Serialize(stream, data);
    stream.Close();
  }

  public static PlayerData LoadPlayer()
  {
    string path = Application.persistentDataPath + "/playerSave";

    if(File.Exists(path))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();

        return data;
    }
    else
    {
        Debug.LogError("Save file not found" + path);
        return null;
    }
  }
}
