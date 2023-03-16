using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public TMP_Text TimeField;
    public TMP_Text LapCountField;
    public TMP_Text LastByOneLapTimeField;
    public TMP_Text LastLapTimeField;

    private const int Multiplier = 3;
    private const int Speed = 10;
    private readonly float[] _floats = new float[] { 7.7f, 1.4f, 5.5f, 6.5f, -0.5f };
    private List<float> _checkpoints = new List<float>();

    private int _passedTime;

    void Start()
    {
        foreach (float num in _floats)
        {
            var instResult = Mathf.Round(num);
            Debug.Log(instResult);
        }
    }

    void Update()
    {
        _passedTime = Mathf.RoundToInt(Time.time * Multiplier);
        TimeField.text = _passedTime.ToString() + " seconds";
    }

    public void OnLapButtonClick()
    {
        _checkpoints.Add(Time.time * Multiplier);
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

}
