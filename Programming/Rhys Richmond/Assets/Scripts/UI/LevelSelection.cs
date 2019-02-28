using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{


    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        Scene CurrentIndex  = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentIndex.name);
    }
}
