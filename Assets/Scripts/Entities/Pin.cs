using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pin : MonoBehaviour, IPin
{
    [SerializeField]
    private string Position;

    public StatesRange StatesRange { get; private set; }
    public int CorrectState { get; private set; }

    private int _currentState;
    public int CurrentState
    {
        get => _currentState;
        set
        {
            switch (StatesRange.CheckStateEntry(value))
            {
                case StateToRangeRelation.Lower:
                    _currentState = StatesRange.LowState; break;
                case StateToRangeRelation.Upper:
                    _currentState = StatesRange.HighState; break;
                default:
                    _currentState = value; break;
            }
            _textField.text = _currentState.ToString();
        }
    }

    private TMP_Text _textField;

    private void Start()
    {
        _textField = GetComponentInChildren<TMP_Text>();

        StatesRange = InitialFactory.GetStatesRange();
        CorrectState = InitialFactory.GetCorrectState();
        CurrentState = Convert.ToInt32(Position);
    }
}


public class StatesRange
{
    public int LowState;
    public int HighState;
    public StateToRangeRelation CheckStateEntry(int state)
    {
        if (state < LowState) return StateToRangeRelation.Lower;
        else if (state > HighState) return StateToRangeRelation.Upper;
        else return StateToRangeRelation.InRange;
    }
}

public enum StateToRangeRelation: byte
{
    InRange, Lower, Upper
}
