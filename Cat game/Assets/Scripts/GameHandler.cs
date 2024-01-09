using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    float timePassed = 0;
    float endTime = 30f;
    float timeTick = 0.1f;

    public TMP_Text timerText;
    public GameObject winScreen;
    public Cat cat;

    


    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if(timePassed >= endTime)
        {
            winScreen.SetActive(true);
            
        }
    }

    IEnumerator Timer()
    {
        while (timePassed < endTime)
        {
            timePassed += timeTick;
            int min = Mathf.FloorToInt((endTime - timePassed) / 60);
            int sec = Mathf.FloorToInt((endTime - timePassed) % 60);
            if (min < 0)
                min = 0;

            if (sec < 0)
                sec = 0;

            string secString = sec < 10 ? $"0{sec}" : sec.ToString();
            timerText.text = $"{min} : {secString}";
            yield return new WaitForSeconds(timeTick);
        }
    }
}
