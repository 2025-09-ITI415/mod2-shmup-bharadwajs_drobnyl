using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour

{

    private TMP_Text _timerText;
    enum TimerType
    {
        CountUp,
        Countdown
    }
    [SerializeField] private TimerType timerType;
    [SerializeField] private float timeToDisply = 60.0f; // Time in seconds for countdown or count up

    private bool _isRunning;
    private float timeToDisplay;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    public void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventmanagerOnTimerUpdate;
    }

    public void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventmanagerOnTimerUpdate;
    }

    private void EventManagerOnTimerStart() => _isRunning = true;
    
    private void EventManagerOnTimerStop() => _isRunning = false;

    private void EventmanagerOnTimerUpdate(float value) => timeToDisply += value;


    private void Update()
    {
        if (!_isRunning) return;
        if (timerType == TimerType.Countdown && timeToDisply < 0.0f)
        {
            EventManager.OnTimerStop();
            return;
        }
        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timerText.text = timeSpan.ToString(format:@"mm\:ss\:ff");
    }


}
















  