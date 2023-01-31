using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingTrigger : MonoBehaviour
{
    [SerializeField] private PanicMechanic panic;
    [SerializeField] private SliderBreath slider;
    void Start()
    {
        
    }

    void Update()
    {
        if(slider.breath.value <= 0f)
        {
            panic.Panic1();
            slider.gameObject.SetActive(false);
        }
    }
}
