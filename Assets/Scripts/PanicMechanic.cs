using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.Audio;

public class PanicMechanic : MonoBehaviour
{
    [SerializeField] private FirstPersonController fps;
    [SerializeField] private GameObject panic1UI;
    [SerializeField] private float panicLevel;
    [SerializeField] private List<GameObject> panic1Buttons;
    [SerializeField] private Slider panicLevelSlider;

    [SerializeField] private ContollableBar bar;
    [SerializeField] private GameObject barObject;
    private int panic1ButtonIndex = 0;
    private float startPanicLevel = 0.5f;

    public bool isPanicking = false;

    public AudioMixer musicMixer;
    public AudioMixer heartbeatMixer;
    private Scenemanager scenemanager;

    void Start()
    {
        panicLevel = startPanicLevel;
        scenemanager = FindObjectOfType<Scenemanager>();
    }

    void Update()
    {
        if(panicLevel >= 1)
        {//good
            PanicOver1();
            isPanicking = false;
        }
        else if(panicLevel <= 0)
        {//bad
            PanicOver1();
            isPanicking = false;
            scenemanager.restartScene();
        }
        panicLevelSlider.value = panicLevel;
    }

    public void buttonPanicPressed()
    {
        panicLevel += 0.1f;

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
            panicLevel -= 0.1f;
        }
    }

    public void Panic1()
    {
        if (!panic1UI.activeSelf)
        {
            fps.enabled = false;

            panicLevel = startPanicLevel;
            Cursor.lockState = CursorLockMode.None;
            panic1UI.SetActive(true);
            StartCoroutine(IncreasePanic());

            musicMixer.SetFloat("distortionLv", 0.85f);
            musicMixer.SetFloat("musicVol", 0f);
            heartbeatMixer.SetFloat("heartbeatVol", 20f);
        }  
        
    }
    public void PanicOver1()
    {
        if (panic1UI.activeSelf)
        {
            StopAllCoroutines();
            Cursor.lockState = CursorLockMode.Locked;
            panic1UI.SetActive(false);

            barObject.SetActive(true);
            bar.isControlActive = true;

            fps.enabled = true;

            musicMixer.SetFloat("distortionLv", 0f);
            musicMixer.SetFloat("musicVol", 10f);
            heartbeatMixer.SetFloat("heartbeatVol", -80f);
        }      
    }
}
