using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public int Stars;

    public int Jumps;
    public int Coins;

    public int TotalScore;
    public void Awake()
    {
        int CurrentIndex = SceneManager.GetActiveScene().buildIndex;
        Jumps = GameObject.Find("Character").GetComponent<Slingshot>().SlingShotTimes;
        Coins = GameObject.Find("Character").GetComponent<Slingshot>().CollectibleCounter;

        TotalScore = Jumps - Coins;

        if (CurrentIndex == 1)
        {
            if (TotalScore < 7 && TotalScore > 5)
            {
                Stars = 1;
            }
            else if (TotalScore < 5 && TotalScore >= 4)
            {
                Stars = 2;
            }
            else if (TotalScore <= 3)
            {
                Stars = 3;
            }
        }
        GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level1Stars = Stars;
        

    }

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
