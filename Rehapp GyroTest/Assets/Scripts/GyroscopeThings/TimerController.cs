using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private float maxTime = 1;
    private float minutes = 0;
    private float seconds = 0;
    private TextMeshProUGUI timerText;
    public bool runningTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        //maxTime = Manager.GetInstance().temporalActivity.duration;
        timerText = GetComponent<TextMeshProUGUI>();
        //gameObject.SetActive(false);
    }

    public void resetTimer()
    {
        minutes = maxTime - 1;
        seconds = 60;
        runningTimer = true;
    }

    // Update is called once per frame
    void Update()
    {

        seconds += Time.deltaTime;

        if (seconds > 60)
        {
            minutes++;
            seconds = 0;
        }

        showTimer();
    }

    private void showTimer()
    {
        if (seconds > 9 && minutes > 9)
        {
            timerText.text = minutes + ":" + (int)seconds;
        }
        else if (seconds < 10 && minutes > 9)
        {
            timerText.text = minutes + ":0" + (int)seconds;
        }
        else if (seconds > 9 && minutes < 10)
        {
            timerText.text = "0" + minutes + ":" + (int)seconds;
        }
        else if (seconds < 10 && minutes < 10)
        {
            timerText.text = "0" + minutes + ":0" + (int)seconds;
        }
    }
}
