using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pin : MonoBehaviour, IPin
{
    [SerializeField]
    private string Position;

    public event Action OnPinObjectInitialized;
    public PinState State { get => CheckState(); }
    public PositionsRange PositionsRange { get; private set; }
    public int CorrectPosition { get; private set; }

    private int _currentPosition;
    private TMP_Text _textField;
    public int CurrentPosition
    {
        get => _currentPosition;
        set
        {
            switch (PositionsRange.CheckPositionEntry(value))
            {
                case PositionToRangeRelation.Lower:
                    _currentPosition = PositionsRange.LowestPosition; break;
                case PositionToRangeRelation.Upper:
                    _currentPosition = PositionsRange.HighestPosition; break;
                default:
                    _currentPosition = value; break;
            }
            if (_textField != null)
            {
                _textField.text = _currentPosition.ToString();
            }
        }
    }

    public void ResetPin()
    {
        //var random = new System.Random();

        PositionsRange = InitialFactory.GetStatesRange();
        CorrectPosition = InitialFactory.GetCorrectState();
        //CurrentPosition = random.Next(PositionsRange.LowestPosition, PositionsRange.HighestPosition);
    }

    private void Start()
    {
        _textField = GetComponentInChildren<TMP_Text>();
        OnPinObjectInitialized?.Invoke();
    }

    private void Awake()
    {
        ResetPin();
    }

    private PinState CheckState()
    {
        return CurrentPosition == CorrectPosition
            ? PinState.CorrectPosition
            : PinState.IncorrectPosition;
    }
}


public class PositionsRange
{
    public int LowestPosition;
    public int HighestPosition;
    public PositionToRangeRelation CheckPositionEntry(int state)
    {
        if (state < LowestPosition) return PositionToRangeRelation.Lower;
        else if (state > HighestPosition) return PositionToRangeRelation.Upper;
        else return PositionToRangeRelation.InRange;
    }
}

public enum PositionToRangeRelation : byte
{
    InRange, Lower, Upper
}

public enum PinState : byte
{
    CorrectPosition,
    IncorrectPosition
}
