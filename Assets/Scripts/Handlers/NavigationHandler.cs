using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavigationHandler : MonoBehaviour
{
    public GameObject PopupFrame;
    public GameObject ContentFrame;
    public GameObject InitialFrame;
    public GameObject ExitButton;
    public GameObject PopupBackgroundPanel;
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

        var tmp = Resources.Load<Sprite>("Images/Escaped");
//                : Resources.Load<Sprite>("Images/Caught");
    }

    public void StartGame()
    {
        InitialFrame.SetActive(false);
        PopupFrame.SetActive(false);
        ExitButton.SetActive(true);
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
            PopupBackgroundPanel.GetComponent<Image>().sprite = 
                gameResult == GameResult.Success 
                ? Resources.Load<Sprite>("Images/Escaped") 
                : Resources.Load<Sprite>("Images/Caught");
        }
        _timeHandler.Stop();
        ExitButton.SetActive(false);
    }
}

public enum GameResult : short
{
    Success,
    Loose,
    Abort
}
