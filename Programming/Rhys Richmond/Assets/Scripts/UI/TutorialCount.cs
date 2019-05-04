using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCount : MonoBehaviour
{

    private GameObject TutorialOveriew;
    private void Awake()
    {
        TutorialOveriew = GameObject.FindGameObjectWithTag("tutorials");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Happens");
            TutorialOveriew.GetComponent<Tutorial>().TutorialCount += 1;

        }

    }
}
