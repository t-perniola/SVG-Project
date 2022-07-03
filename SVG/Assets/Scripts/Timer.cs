using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]float timeRemaining;
    [SerializeField]Text timerText;
    public Transform target;
    bool keepTime = false;
    void OnEnable()
    {
        EventManager.onSpaceFightGame += StartTimer;
        //EventManager.OnPlayerDeath += StopTimer;
    }

    void OnDisable()
    {
        EventManager.onSpaceFightGame -= StartTimer;
        //EventManager.OnPlayerDeath -= StopTimer;
    }

    void Update()
    {
        if(keepTime)
        {
          timeRemaining -= Time.deltaTime; 
          UpdateTimerDisplay(); 
        }
        
    }

    void StartTimer()
    {
        timeRemaining = 180;
        keepTime = true;
    }

    void StopTimer()
    {
        keepTime = false;
    }

    void UpdateTimerDisplay()
    {
        int minutes;
        float seconds;

        minutes = Mathf.FloorToInt(timeRemaining/60);
        seconds = timeRemaining%60;

        timerText.text = string.Format("{0}:{1:00.00}", minutes, seconds);
        if(timeRemaining == 0)
        {
            Explosion temp = target.GetComponent<Explosion>();
        }

    }

    

}
