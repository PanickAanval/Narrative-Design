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
}
