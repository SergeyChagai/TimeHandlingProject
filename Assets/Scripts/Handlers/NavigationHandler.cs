using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NavigationHandler : MonoBehaviour
{
    public GameObject PopupFrame;
    public GameObject ContentFrame;
    public GameObject InitialFrame;
    public GameObject ExitButton;
    public TMP_Text InfoTextField;

    public GameObject TimeHandlerObject;
    public GameObject LockHandlerObject;

    private TimeHandler _timeHandler;
    private LockHandler _lockHandler;
    private Dictionary<GameResult, string> _gameResultsMessagesDict;

    void Start()
    {
        _lockHandler = LockHandlerObject.GetComponent<LockHandler>();
        _timeHandler = TimeHandlerObject.GetComponent<TimeHandler>();
        _gameResultsMessagesDict = InitialFactory.GetInfoTextMessages();

        _timeHandler.EndGameAction += HandleEndOfGame;
        _lockHandler.OnUnlock += () => HandleEndOfGame(GameResult.Success);
    }

    public void StartGame()
    {
        InitialFrame.SetActive(false);
        PopupFrame.SetActive(false);
        _lockHandler.ResetLock();
        _timeHandler.Run();
    }

    public void AbortGame() => HandleEndOfGame(GameResult.Abort);

    private void HandleEndOfGame(GameResult gameResult)
    {
        if (gameResult == GameResult.Abort)
        {
            InitialFrame.SetActive(true);
        }
        else
        {
            PopupFrame.SetActive(true);
            InfoTextField.text = _gameResultsMessagesDict[gameResult];
        }
        _timeHandler.Stop();
    }
}

public enum GameResult : short
{
    Success,
    Loose,
    Abort
}
