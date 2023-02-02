using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StartScreen : MonoBehaviour
{
    public NPCConversation startConversation;
    public GameObject blackScreen;
    public GameObject breathing;
    public GameObject convoManager;
    [SerializeField] private GameObject breathShow;

    private void Start()
    {
        StartCoroutine(Wait());
        Cursor.lockState = CursorLockMode.None;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4.5f);
        ConversationManager.Instance.StartConversation(startConversation);
        breathShow.SetActive(true);
    }

    public void BeginGame()
    {
        breathShow.SetActive(false);
        convoManager.SetActive(false);
        blackScreen.SetActive(false);
        breathing.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
