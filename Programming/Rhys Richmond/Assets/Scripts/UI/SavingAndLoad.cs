using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingAndLoad : MonoBehaviour
{
    public void save()
    {
        GameStore.Storage.Save();
    }

    public void Load()
    {
        GameStore.Storage.Load();
    }
}
