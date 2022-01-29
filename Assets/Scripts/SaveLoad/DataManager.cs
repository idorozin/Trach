
using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public PlayerData playerData = new PlayerData();
    private JsonHelper<PlayerData> jsonHelper;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        jsonHelper = new JsonHelper<PlayerData>(playerData,"pd");
        jsonHelper.LoadData();
    }


    public void SaveData()
    {
        jsonHelper.SaveData();
    }

    public void LoadData()
    {
        jsonHelper.LoadData();
    }
}
