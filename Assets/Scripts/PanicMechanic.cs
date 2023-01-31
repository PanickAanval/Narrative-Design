using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicMechanic : MonoBehaviour
{
    [SerializeField] private GameObject panic1UI;
    [SerializeField] private float panicLevel;
    [SerializeField] private List<GameObject> panic1Buttons;
    private int panic1ButtonIndex = 0;
    private float maxPanicLevel = 10f;
    private float tempPanic;

    void Start()
    {
        
    }

    void Update()
    {
        if(panicLevel <= 0)
        {
            PanicOver1();
        }
    }

    public void setLevel(float changeValue)
    {
        panicLevel += changeValue;
    }

    public void SetPanic1ButtonsActive()
    {
        if (panic1ButtonIndex <= panic1Buttons.Count)
        {
            panic1Buttons[panic1ButtonIndex].SetActive(false);
            panic1ButtonIndex++;
            if (panic1ButtonIndex >= panic1Buttons.Count)
            {
                panic1ButtonIndex = 0;
                panic1Buttons[panic1ButtonIndex].SetActive(true);
            }
            else
            {
                panic1Buttons[panic1ButtonIndex].SetActive(true);
            }
        }
        
    }

    public void Panic1()
    {
        //stop moving
        panicLevel = maxPanicLevel;
        Cursor.lockState = CursorLockMode.None;
        panic1UI.SetActive(true);

        
        
    }
    public void PanicOver1()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panic1UI.SetActive(false);
        //start moving
        
    }
}
