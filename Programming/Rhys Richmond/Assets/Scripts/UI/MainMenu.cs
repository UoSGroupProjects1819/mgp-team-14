using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text Level1StarsText;
    public Text Level2StarsText;
    public GameObject Level2StarsTextgo;
    public Text Level3StarsText;
    public GameObject Level3StarsTextgo;
    public Text Level4StarsText;
    public GameObject Level4StarsTextgo;
    public Text Level5StarsText;
    public GameObject Level5StarsTextgo;

    private int Level1Stars;
    private int Level2Stars;
    private int Level3Stars;
    private int Level4Stars;
    private int Level5Stars;

    public bool BackToMenu = false;

    public GameObject Level2Stop;
    public GameObject Level3Stop;
    public GameObject Level4Stop;
    public GameObject Level5Stop;

    public GameObject LevelPanel;

    public void Awake()
    {
        Level1Stars = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level1Stars;
        Level2Stars = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level2Stars;
        Level3Stars = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level3Stars;
        Level4Stars = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level4Stars;
        Level5Stars = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level5Stars;
        BackToMenu = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().BackToMenu;
        Level1StarsText.text = "Stars : " + Level1Stars;
        Level2StarsText.text = "Stars : " + Level2Stars;
        Level3StarsText.text = "Stars : " + Level3Stars;
        Level4StarsText.text = "Stars : " + Level4Stars;
        Level5StarsText.text = "Stars : " + Level5Stars;

        if (GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().TotalStars >= 3)
        {
            Level2Stop.SetActive(false);
            Level2StarsTextgo.SetActive(true);
        }
        if (GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().TotalStars >= 6)
        {
            Level3Stop.SetActive(false);
            Level3StarsTextgo.SetActive(true);
        }
        if (GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().TotalStars >= 9)
        {
            Level4Stop.SetActive(false);
            Level4StarsTextgo.SetActive(true);
        }
        if (GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().TotalStars >= 12)
        {
            Level5Stop.SetActive(false);
            Level5StarsTextgo.SetActive(true);
        }

        if (BackToMenu == false)
        {
            LevelPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Stuff happens");
            this.gameObject.SetActive(false);
        }
    }

   public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        SceneManager.LoadScene(5);
    }
    public void Quit()
    {
        Application.Quit();
    }


    
}
