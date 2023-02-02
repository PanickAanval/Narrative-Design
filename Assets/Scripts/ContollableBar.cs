using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContollableBar : MonoBehaviour
{
    [SerializeField] private Image controllable;
    [SerializeField] private GameObject panic2;
    [SerializeField] private PanicMechanic panic;
    [SerializeField] private AudioSource breathIn;
    [SerializeField] private AudioSource breathOut;
    private Vector2 temp;
    public bool isControlActive = true;
    void Start()
    {
        temp = controllable.rectTransform.anchoredPosition;
    }

    private void Update()
    {
        if (isControlActive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!breathIn.isPlaying)
                {
                    breathIn.Play();
                }
                else if (breathOut.isPlaying)
                {
                    breathOut.Stop();
                }
                
                temp.y += 2f;
                controllable.rectTransform.anchoredPosition = temp;
            }
        }
    }

    void FixedUpdate()
    {
        if (isControlActive)
        {
            moveDown();
        }
    }

    private void moveDown()
    {
        if (!breathOut.isPlaying)
        {
            breathOut.Play();
        }
        else if (breathIn.isPlaying)
        {
            breathIn.Stop();
        }

        temp.y -= 2f;
        controllable.rectTransform.anchoredPosition = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isControlActive = false;
        panic2.SetActive(false);
        temp.y = 0;
        controllable.rectTransform.anchoredPosition = temp;

        panic.Panic1();
    }
}
