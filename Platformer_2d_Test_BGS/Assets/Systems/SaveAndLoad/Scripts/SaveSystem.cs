using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public static class SaveSystem
{
    public static void SaveInventory(PlayerInventoryData playerInventoryData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + GlobalConstants.playerDataPath;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, playerInventoryData);
        fileStream.Close();
    }

    public static PlayerInventoryData LoadInventory()
    {
        string path = Application.persistentDataPath + GlobalConstants.playerDataPath;

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerInventoryData data = formatter.Deserialize(fileStream) as PlayerInventoryData;

            return data;
        }
        else
        {
            return null;
        }
    }
}
