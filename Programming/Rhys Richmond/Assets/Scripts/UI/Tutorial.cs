using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private GameObject TutorialOveriew;

    private GameObject TutorialPanel1;
    private GameObject TutorialPanel2;
    private GameObject TutorialPanel3;

    public int TutorialCount = 0;
    private void Awake()
    {
        TutorialOveriew = GameObject.FindGameObjectWithTag("tutorials");

        TutorialPanel1 = GameObject.Find("Tutorial1Panel");
        TutorialPanel2 = GameObject.Find("Tutorial2Panel");
        TutorialPanel3 = GameObject.Find("Tutorial3Panel");
        TutorialPanel2.SetActive(false);
        TutorialPanel3.SetActive(false);
    }

    private void Update()
    {
        if (TutorialCount == 1)
        {
            TutorialPanel1.SetActive(false);
            TutorialPanel2.SetActive(true);
        }
        else if (TutorialCount == 2)
        {
            TutorialPanel2.SetActive(false);
            TutorialPanel3.SetActive(true);
        }
        else if (TutorialCount == 3)
        {
            TutorialPanel3.SetActive(false);
        }
    }
}
