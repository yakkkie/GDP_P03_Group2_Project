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
    public GameObject LoseScreen1;
    public GameObject LoseScreen2;




    private void Start()
    {
        StartCoroutine(Timer());
        LoseScreen1 = GameObject.Find("Lose1");
        LoseScreen2 = GameObject.Find("Lose2");
    }

    private void Update()
    {
        if(timePassed >= endTime)
        {
            winScreen.SetActive(true);
            
        }
        if(LoseScreen1|| LoseScreen2)
        {
            winScreen.SetActive(false);
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
