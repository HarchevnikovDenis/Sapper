using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private float time;
    private int min = 0;
    private int sec = 0;
    private float timeMS;
    private string str;

    private void Start()
    {
        time = 0.0f;
        timeMS = 0.0f;
        timeText.text = "00:00";
        str = string.Empty;
    }

    private void Update()
    {
        if (!BuildMap.isFirstStepDone)
            return;

        time += Time.deltaTime;
        timeMS += Time.deltaTime;

        if(timeMS >= 60)
        {
            min++;
            sec = 0;
            timeMS -= 60.0f;
        }

        sec = (int)timeMS;

        str = string.Format("{0:00}:", min);
        str += string.Format("{0:00}", sec);

        timeText.text = str.ToString();
    }
}
