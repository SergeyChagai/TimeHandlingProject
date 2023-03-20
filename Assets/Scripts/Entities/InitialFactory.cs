using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialFactory
{
    private const int LowStateConst = 0;
    private const int HighStateConst = 10;
    private const int CorrectState = 5;
    private const int TimerRate = 10;

    public static PositionsRange GetStatesRange()
    {
        return new PositionsRange()
        {
            LowestPosition = LowStateConst,
            HighestPosition = HighStateConst
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

    public static Dictionary<GameResult, string> GetInfoTextMessages()
    {
        var dict = new Dictionary<GameResult, string>();
        dict.Add(GameResult.Success, "Congratulations! You win :)");
        dict.Add(GameResult.Loose, "You loose :(");
        dict.Add(GameResult.Abort, "Game was stopped");
        return dict;
    }

    public static List<ToolDTO> GetToolDtoList()
    {
        var toolJsonFile = Resources.Load<TextAsset>("Data/tools_affect_data");
        return JsonConvert.DeserializeObject<List<ToolDTO>>(toolJsonFile.text);
    }

    public static List<StartPositionDTO> GetStartPositionDtoList() 
    {
        var startPositionJsonFile = Resources.Load<TextAsset>("Data/start_positions");
        return JsonConvert.DeserializeObject<List<StartPositionDTO>>(startPositionJsonFile.text);
    }

}


