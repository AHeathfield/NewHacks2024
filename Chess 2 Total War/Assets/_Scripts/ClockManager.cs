using UnityEngine;
using TMPro;
using System;

public class ClockManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI timer1Text;
    [SerializeField] TextMeshProUGUI timer2Text;
    public float remainingTime1 = 300;
    public float remainingTime2 = 300;
    private bool timer1 = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toggle();
        }

        if (timer1)
        {
            if (remainingTime1 > 0)
            {
                remainingTime1 -= Time.deltaTime;

                if (remainingTime1 < 0)
                {
                    remainingTime1 = 0;
                }

                int minutes = Mathf.FloorToInt(remainingTime1/60);
                int seconds = Mathf.FloorToInt(remainingTime1 % 60);
                timer1Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            
        } else //timer2
        {
            if (remainingTime2 > 0)
            {
                remainingTime2 -= Time.deltaTime;

                if (remainingTime2 < 0)
                {
                    remainingTime2 = 0;
                }

                int minutes = Mathf.FloorToInt(remainingTime2/60);
                int seconds = Mathf.FloorToInt(remainingTime2 % 60);
                timer2Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

       // int minutes = Mathf.FloorToInt(remainingTime1/60);
        //int seconds = Mathf.FloorToInt(remainingTime1 % 60);
        //timer1Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Toggle()
    {
        timer1 = !timer1;
    }
}
