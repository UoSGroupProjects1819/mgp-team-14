using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public int Stars;

    public int Jumps;
    public int Coins;
    public int TotalScore;

    private Image ImageR;
    public Sprite[] Sprites;

    public GameObject ImageComp;
    
    public void Awake()
    {
        int CurrentIndex = SceneManager.GetActiveScene().buildIndex;
        ImageR = ImageComp.GetComponent<Image>();
        Jumps = GameObject.Find("Character").GetComponent<Slingshot>().SlingShotTimes;
        Coins = GameObject.Find("Character").GetComponent<Slingshot>().CollectibleCounter;

        TotalScore = Jumps - Coins;

        if (CurrentIndex == 1)
        {
            if (TotalScore < 20 && TotalScore > 15)
            {
                Stars = 1;
                //Stars = 3;
            }
            else if (TotalScore < 14 && TotalScore >= 11)
            {
                //Stars = 2;
                Stars = 2;
            }
            else if (TotalScore <= 10)
            {
                //Stars = 3;
                Stars = 3;
            }
            GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level1Stars = Stars;
        }
        else if (CurrentIndex == 2)
        {
            if (TotalScore < 20 && TotalScore > 15)
            {
                Stars = 1;
                //Stars = 3;
            }
            else if (TotalScore < 14 && TotalScore >= 11)
            {
                //Stars = 2;
                Stars = 2;
            }
            else if (TotalScore <= 10)
            {
                //Stars = 3;
                Stars = 3;
            }
            GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level2Stars = Stars;
        }
        else if (CurrentIndex == 3)
        {
            if (TotalScore < 20 && TotalScore > 15)
            {
                Stars = 1;
                //Stars = 3;
            }
            else if (TotalScore < 14 && TotalScore >= 11)
            {
                //Stars = 2;
                Stars = 2;
            }
            else if (TotalScore <= 10)
            {
                //Stars = 3;
                Stars = 3;
            }
            GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level3Stars = Stars;
        }
        else if (CurrentIndex == 4)
        {
            if (TotalScore < 20 && TotalScore > 15)
            {
                Stars = 1;
                //Stars = 3;
            }
            else if (TotalScore < 14 && TotalScore >= 11)
            {
                //Stars = 2;
                Stars = 2;
            }
            else if (TotalScore <= 10)
            {
                //Stars = 3;
                Stars = 3;
            }
            GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level4Stars = Stars;
        }
        else if (CurrentIndex == 5)
        {
            if (TotalScore < 20 && TotalScore > 15)
            {
                Stars = 1;
                //Stars = 3;
            }
            else if (TotalScore < 14 && TotalScore >= 11)
            {
                //Stars = 2;
                Stars = 2;
            }
            else if (TotalScore <= 10)
            {
                //Stars = 3;
                Stars = 3;
            }
            GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level5Stars = Stars;
        }


        if (Stars == 0)
        {
            ImageR.sprite = Sprites[0];
        }
        else if (Stars == 1)
        {
            ImageR.sprite = Sprites[1];
        }
        else if (Stars == 2)
        {
            ImageR.sprite = Sprites[2];
        }
        else if (Stars == 3)
        {
            ImageR.sprite = Sprites[3];
        }
    }

    public void BacktoMenu()
    {
        Debug.Log("Does this happen?");
        GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().BackToMenu = true;
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        Scene CurrentIndex  = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentIndex.name);
    }
}
