using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyManager : MonoBehaviour
{
    public FirstPersonController firstpersoncontroller;
    public float timeremaining = 3;
    public bool timerrunning = false;
    public float anxietyscore = 0;
    public void StartMinigame()
    {
        firstpersoncontroller.enabled = false;
        timerrunning = true;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerrunning == true)
        {
            if (timeremaining > 0)
            {
                timeremaining -= Time.deltaTime;
                Debug.Log(timeremaining);
                if (Input.GetKeyDown("space"))
                {
                    timerrunning = false;
                    timeremaining = 3;
                    firstpersoncontroller.enabled = true;
                    Debug.Log("Slay");
                }
            }
            else
            {
                Debug.Log("Tijd op");
                timerrunning = false;
                timeremaining = 3;
                firstpersoncontroller.enabled = true;
                anxietyscore++;
                if (anxietyscore >= 2)
                {
                    Debug.Log("Lose");
                }
            }
        }

       
    }
}
