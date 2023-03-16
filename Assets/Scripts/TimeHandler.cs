using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public TMP_Text TimeField;
    public TMP_Text LapCountField;

    private const int Multiplier = 3;
    private const int Speed = 10;
    private readonly float[] _floats = new float[] { 7.7f, 1.4f, 5.5f, 6.5f, -0.5f };

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
        LapCountField.text = Convert.ToString(_passedTime / Speed) + " laps";
    }

}
