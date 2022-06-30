using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int time;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += (int)(Time.deltaTime * 1000);
        }
    }

    public void StartTimer(bool resetTimer)
    {
        active = true;
        if (resetTimer)
        {
            time = 0;
        }
    }

    public void StopTimer()
    {
        print("Timer stopped");
        active = false;
    }

    public void ResetTimer()
    {
        active = false;
        time = 0;
    }

    public float GetTimeUnformatted()
    {
        return time;
    }

    public string GetTimeFormatted()
    {
        int msec = time % 1000;
        int sec = (int)(time / 1000 % 60);
        int min = (int)(time / (1000 * 60));
        return string.Format("{0:00}:{1:00}:{2:000}", min, sec, msec);
    }
}
