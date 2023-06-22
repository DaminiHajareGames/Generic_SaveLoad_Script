using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static void SaveData<T>(T toSaveData, string filename)
    {
        string path = Application.persistentDataPath + "/" + filename + ".dat";

        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(path)) 
        {
            FileStream file = File.Open(path, FileMode.Open);
            bf.Serialize(file, toSaveData);
            file.Close();
        }
        else
        {
            Debug.LogError("File not exist");
            FileStream file = File.Create(path);
            bf.Serialize(file, toSaveData);
            file.Close();
        }
    }

   

    public static T LoadData<T>(T inLoadingData, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".dat";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            inLoadingData = (T)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.LogError("File Does Not Exist");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(path);
            bf.Serialize(file, inLoadingData);
            file.Close();
        }
        return inLoadingData;
    }

    public static bool CheckIfFileExists(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".dat";
        if (File.Exists(path))
            return true;
        else
            return false;
    }

    public static void DeleteFile(string fileName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + fileName + ".dat";
        
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void DeleteAllFiles()
    {
        DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
        dataDir.Delete(true);
    }
}