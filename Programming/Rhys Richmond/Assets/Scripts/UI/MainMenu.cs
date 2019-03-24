using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text Level1StarsText;
    public int Level1Stars;

    public GameObject Level2Stop;

    public void Awake()
    {
        Level1Stars = GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().Level1Stars;
        Level1StarsText.text = "Stars : " + Level1Stars;
    }

    public void Update()
    {
        if (GameObject.Find("GlobalVariableStore").GetComponent<GameStore>().TotalStars >= 3)
        {
            Level2Stop.SetActive(false);
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
