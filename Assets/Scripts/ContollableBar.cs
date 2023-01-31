using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContollableBar : MonoBehaviour
{
    [SerializeField] private Image controllable;
    [SerializeField] private GameObject panic2;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                temp.y += 20f;
            }
        }
        else
        {
            panic2.SetActive(false);
            temp.y = 0;
            controllable.rectTransform.anchoredPosition = temp;
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
        temp.y -= 2f;
        controllable.rectTransform.anchoredPosition = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isControlActive = false;
    }
}
