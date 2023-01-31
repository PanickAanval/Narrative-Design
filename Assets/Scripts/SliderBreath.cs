using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBreath : MonoBehaviour
{
    private Slider breath;
    public bool isBreathing = true;

    void Start()
    {
        breath = GetComponent<Slider>();
        breath.value = 1f;
        StartCoroutine(downBreath());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            breath.value = 1f;
        }
    }

    private IEnumerator downBreath()
    {
        while(isBreathing)
        {
            breath.value -= 0.1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
