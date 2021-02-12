using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    
    public static void SaveGame<T>(T data) {
        BinaryFormatter bf = new BinaryFormatter();
        if (Debug.isDebugBuild) {
            Debug.Log("Save path: " + Application.persistentDataPath);
        }
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, data);
        file.Close();
    }

    public static bool LoadGame<T>(out T data) {
        try {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate)) {
                data = (T) bf.Deserialize(file);
            }
            return true;
        }
        catch(SerializationException e) {
            Debug.Log(e);
            data = default;
            return false;
        }
    }

}
