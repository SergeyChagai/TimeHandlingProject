using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public TMP_Text TimeField;
    public Action<GameResult> EndGameAction;

    // Time booster for tests
    #region Multiplier
#if DEBUG
    [SerializeField]
    private int _multiplier;
#else
    private int _multiplier = 1;
#endif
    #endregion

    // Time for display
    #region TimerTime
    private int _timerTime;
    public int TimerTime
    {
        get => _timerTime;
        set
        {
            if (value >= 0)
            {
                _timerTime = value;
                TimeField.text = _timerTime.ToString();
            }
            else EndGameAction?.Invoke(GameResult.Loose);
        }
    }
    #endregion

    private float _startTime;
    private int _passedTime;
    private int _timerRange;
    private TimerState _state;


    private void Start()
    {
        _timerRange = InitialFactory.GetTimerRange();
    }

    void Update()
    {
        if (_state == TimerState.Run)
        {
            _passedTime = Mathf.RoundToInt(GetTime() - _startTime);
            TimerTime = _timerRange - _passedTime;
        }
    }


    public void Run()
    {
        _startTime = GetTime();
        _state = TimerState.Run;
    }

    public void Stop()
    {
        ClearFields();
        _state = TimerState.Stop;
    }


    private float GetTime() => Time.time * _multiplier;

    private void ClearFields()
    {
        _startTime = 0;
        TimeField.text = "0";
    }
}

public enum TimerState : short
{
    Stop,
    Run
}
