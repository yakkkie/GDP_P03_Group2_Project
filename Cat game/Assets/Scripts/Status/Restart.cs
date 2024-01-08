using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Cat catScript; // Reference to the Cat script

    void Start()
    {
        catScript = GameObject.Find("Cat Lite").GetComponent<Cat>();
        if (catScript == null)
        {
            Debug.LogError("Cat script not found on the GameObject.");
        }
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ReinitializeOtherScript()
    {
        if (catScript != null)
        {
            catScript.Initialize(); // Assuming Cat script has an Initialize method
        }
        else
        {
            Debug.LogError("Cat script is not assigned. Cannot reinitialize.");
        }
    }
}

