
using System.Data;
using System.IO;
using UnityEngine;

public class JsonHelper<T>
{
    private string path;
    private T dataClass;

    public JsonHelper(T dataClass, string key)
    {
        this.dataClass = dataClass;
        path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + $"xd_{key}.json";
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(dataClass);
        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
    }

    public void LoadData()
    {
        if(!File.Exists(path))
            SaveData();
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        JsonUtility.FromJsonOverwrite(json, dataClass);
    }

}
