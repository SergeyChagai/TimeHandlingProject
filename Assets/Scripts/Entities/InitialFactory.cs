using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialFactory
{
    private const int LowStateConst = 0;
    private const int HighStateConst = 10;
    private const int CorrectState = 5;
    
    private const int TimerRate = 60;
    public static StatesRange GetStatesRange()
    {
        return new StatesRange()
        {
            LowState = LowStateConst,
            HighState = HighStateConst
        };
    }

    public static int GetCorrectState()
    {
        return CorrectState;
    }

    public static int GetTimerRange()
    {
        return TimerRate;
    }

}
