using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TMP_Text timeToEndText;

    private int secondsToEnd;
    private GameManager gameManager;
    
    public void SetParametrs(int seconds)
    {
        secondsToEnd = seconds;
        gameManager = GetComponent<GameManager>();
        TimerPrint();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (secondsToEnd > 0)
        {
            yield return new WaitForSeconds(1);

            secondsToEnd -= 1;
            TimerPrint();
        }
        gameManager.GameOver();
    }

    private void TimerPrint()
    {
        timeToEndText.text = TimeSpan.FromSeconds(secondsToEnd).ToString();
    }

    public void TimeIncreasing()
    {
        secondsToEnd++;
        TimerPrint();
    }

    public void TimeDecrease()
    {
        secondsToEnd--;
        TimerPrint();
    }

}
