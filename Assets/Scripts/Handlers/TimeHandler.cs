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
            _timerTime = value;
            TimeField.text = _timerTime.ToString();
        }
    }
    #endregion

    private float _startTime;
    private int _passedTime;
    private int _timerRange;


    private void Start()
    {
        _timerRange = InitialFactory.GetTimerRange();
    }

    void Update()
    {
        if (_startTime != 0)
        {
            _passedTime = Mathf.RoundToInt(GetTime() - _startTime);
            TimerTime = _timerRange - _passedTime;
        }
    }


    public void OnStartButtonClick()
    {
        _startTime = GetTime();
    }

    public void OnExitButtonButtonClick()
    {
        ClearFields();
    }


    private float GetTime() => Time.time * _multiplier;

    private void ClearFields()
    {
        _startTime = 0;
        TimeField.text = "0";
    }
}

public enum States: short
{
    InactiveState,
    RunState
}

public enum GameResult : short
{
    Success,
    Loose,
    Abort
}
