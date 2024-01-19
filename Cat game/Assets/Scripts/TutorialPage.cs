using UnityEngine;

public class TutorialPage : MonoBehaviour
{
    public GameObject nextPage;
    public GameObject prevPage;

    private TutorialHandler tutorialHandler;

    public void GoNext()
    {
        nextPage.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void GoPrev()
    {
        prevPage.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        tutorialHandler = GameObject.Find("TutorialHandler").GetComponent<TutorialHandler>();
        tutorialHandler.OnTutorialClose();
    }


}
