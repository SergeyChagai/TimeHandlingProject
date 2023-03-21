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
        dict.Add(GameResult.Success, "Congratulations! You win :)\nAs you focus on the lock mechanism, your fingers move deftly over the tumblers. You hear a satisfying click and the lock opens. With a grin of triumph, you push the door open and step out of your cell. You are free! You sneak past the sleeping guards and make your way out of the prison, elated at your success. You know that you'll need to keep a low profile for a while, but you can't help but feel a rush of excitement at the thought of your next heist.");
        dict.Add(GameResult.Loose, "You loose :(\nYour hands shake as you attempt to manipulate the lock, but the tumblers refuse to budge. After several minutes of fruitless effort, you realize that you're not going to be able to pick the lock. Your heart sinks as you hear footsteps approaching. The guards have discovered your attempts to escape. You brace yourself for the punishment that is sure to come, knowing that your dreams of a life of crime have come to an abrupt end.");
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


