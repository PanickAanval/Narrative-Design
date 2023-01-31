using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanicMechanic : MonoBehaviour
{
    [SerializeField] private GameObject panic1UI;
    [SerializeField] private int panicLevel;
    [SerializeField] private List<GameObject> panic1Buttons;
    [SerializeField] private TMP_Text panicLevelText;
    [SerializeField] private SliderBreath slider;
    private int panic1ButtonIndex = 0;
    private int maxPanicLevel = 10;

    public bool isPanicking = false;

    void Start()
    {
        panicLevel = maxPanicLevel;
    }

    void Update()
    {
        if(panicLevel <= 0)
        {//good
            PanicOver1();
            isPanicking = false;
        }
        else if(panicLevel >= 15)
        {//bad
            PanicOver1();
            isPanicking = false;
        }
        panicLevelText.text = panicLevel.ToString();
    }

    public void buttonPanicPressed()
    {
        panicLevel -= 1;

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

    public IEnumerator IncreasePanic()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            panicLevel++;
        }
    }

    public void Panic1()
    {
        //stop moving
        if (!panic1UI.activeSelf)
        {
            panicLevel = maxPanicLevel;
            Cursor.lockState = CursorLockMode.None;
            panic1UI.SetActive(true);
            StartCoroutine(IncreasePanic());
        }  
        
    }
    public void PanicOver1()
    {
        if (panic1UI.activeSelf)
        {
            StopAllCoroutines();
            Cursor.lockState = CursorLockMode.Locked;
            panic1UI.SetActive(false);
            slider.gameObject.SetActive(true);
            slider.resetSlider();
        }
        //start moving
        
    }
}
