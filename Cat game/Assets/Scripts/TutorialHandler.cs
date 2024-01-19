using UnityEngine;
using Patterns;
using UnityEngine.SceneManagement;

public class TutorialHandler : Singleton<TutorialHandler>
{
    public bool tutorialShown = false;
    public GameObject tutorialCanvas;

    void Start()
    {

        
    }

    public void OnTutorialClose()
    {

        tutorialShown = true;
        
        HideTutorialPopup();
    }

    private void ShowTutorialPopup()
    {
        
        Time.timeScale = 0;
        tutorialCanvas.SetActive(true);
    }

    private void HideTutorialPopup()
    {
        
        tutorialCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(GameObject.Find("Tutorial"));
        if (scene.name == "GameScene")
        {

            tutorialCanvas = GameObject.Find("Tutorial");
            if (!tutorialShown)
            {
                ShowTutorialPopup();
            }else if (tutorialShown)
            {
                HideTutorialPopup();
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
