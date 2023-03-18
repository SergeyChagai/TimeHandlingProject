using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LockHandler : MonoBehaviour
{
    public GameObject TimeHandlerObject;
    private TimeHandler _timeHandler;

    void Start()
    {
        _timeHandler = TimeHandlerObject.GetComponent<TimeHandler>();
        _timeHandler.EndGameAction += HandleEndOfGame;
    }

    private void HandleEndOfGame(GameResult gameResult)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        
    }
}
