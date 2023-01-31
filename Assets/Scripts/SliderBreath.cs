using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBreath : MonoBehaviour
{
    public Slider breath;

    void Start()
    {
        breath = GetComponent<Slider>();
        resetSlider();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            breath.value = 1f;
        }
    }

    public void resetSlider()
    {
        breath.value = 1f;
    }

    private void FixedUpdate()
    {
        breath.value -= 0.01f;
    }
}
