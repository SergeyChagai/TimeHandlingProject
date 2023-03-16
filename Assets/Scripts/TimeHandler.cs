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
    public TMP_Text LapCountField;
    public TMP_Text LastByOneLapTimeField;
    public TMP_Text LastLapTimeField;

    [SerializeField]
    private int _multiplier;

    private List<float> _checkpoints = new List<float>();
    private int _passedTime;
    private float _timeOfPreviousLap;
    private float _startTime;

    
    void Update()
    {
        _passedTime = Mathf.RoundToInt(GetStartTime());
        TimeField.text = _passedTime.ToString() + " seconds";
    }

   
    public void OnStartButtonClick()
    {
        _startTime = GetBoostedTime();
    }

    public void OnExitButtonButtonClick()
    {
        ClearFields();
    }

    public void OnLapButtonClick()
    {
        var rangeOfLap = GetRangeOfLap();
        _timeOfPreviousLap = GetBoostedTime();
        _checkpoints.Add(rangeOfLap);
        LapCountField.text = _checkpoints.Count.ToString() + " laps";
        FinishCurrentLap();
    }

    private void FinishCurrentLap()
    {
        LastLapTimeField.text = $"{_checkpoints.Last()} sec";

        var capacity = _checkpoints.Count;
        if (capacity > 1)
        {
            LastByOneLapTimeField.text = $"{_checkpoints[capacity - 2]/*Index of last by one item*/}";
        }
    }

    private float GetBoostedTime() => Time.time * _multiplier;

    private float GetRangeOfLap() => GetBoostedTime() - _timeOfPreviousLap;
    

    private float GetStartTime() => GetBoostedTime() - _startTime;

    private void ClearFields()
    {
        _checkpoints.Clear();
        TimeField.text = "0 seconds";
        LapCountField.text = "0 laps";
        LastByOneLapTimeField.text = "-";
        LastLapTimeField.text = "-";
    }
}
