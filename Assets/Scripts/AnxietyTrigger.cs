using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnxietyTrigger : MonoBehaviour
{
    public AnxietyManager manager;
    private bool activated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            manager.StartMinigame();
            activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
         

    }
}
