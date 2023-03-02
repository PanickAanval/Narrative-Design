using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public void restartScene()
    {
        SceneManager.LoadScene("MechanicTest");
    }

    public void transformScene()
    {
        SceneManager.LoadScene("TransformedScene");
    }

    public void endScene()
    {
        SceneManager.LoadScene("CreditScene");
        Cursor.lockState = CursorLockMode.None;
    }

    public void creditScene()
    {
        SceneManager.LoadScene("EndCreditScene");
    }

    public void quit()
    {
        Application.Quit();
    }
}
