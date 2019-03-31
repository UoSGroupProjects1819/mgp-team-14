using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameStore : MonoBehaviour
{
    public static GameStore Storage;
    public int TotalStars;
    public int Level1Stars;
    public int Level2Stars;
    public int Level3Stars;
    public int Level4Stars;
    public int Level5Stars;
    void Awake()
    {
        
        if (Storage == null)
        {
            DontDestroyOnLoad(gameObject);
            Storage = this;
        }
        else if (Storage != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        TotalStars = Level1Stars + Level2Stars + Level3Stars + Level4Stars + Level5Stars;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream Savefile = File.Create(Application.persistentDataPath + "/playerSave.dat");

        PlayerData data = new PlayerData();
        data.Stars = TotalStars;
        data.StarsOne = Level1Stars;
        data.StarsTwo = Level2Stars;
        data.StarsThree = Level3Stars;
        data.StarsFour = Level4Stars;
        data.StarsFive = Level5Stars;

        bf.Serialize(Savefile, data);
        Savefile.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerSave.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream Savefile = File.Open(Application.persistentDataPath + "/playerSave.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(Savefile);
            Savefile.Close();

            TotalStars = data.Stars;
            Level1Stars = data.StarsOne;
            Level2Stars = data.StarsTwo;
            Level2Stars = data.StarsThree;
            Level4Stars = data.StarsFour;
            Level5Stars = data.StarsFive;
        }
    }
}
[System.Serializable]
class PlayerData
{
    public int Stars;
    public int StarsOne;
    public int StarsTwo;
    public int StarsThree;
    public int StarsFour;
    public int StarsFive;
}
