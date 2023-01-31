using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingTrigger : MonoBehaviour
{
    [SerializeField] private FloatReference breathValue;
    [SerializeField] private PanicMechanic panic;
    void Start()
    {
        
    }

    void Update()
    {
        if(breathValue.Value <= 0f)
        {
            panic.Panic1();
        }
    }
}
