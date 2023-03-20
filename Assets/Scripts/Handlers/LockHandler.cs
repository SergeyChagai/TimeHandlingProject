using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LockHandler : MonoBehaviour
{
    public event Action OnUnlock;

    private Pin[] _pins;
    private Tool[] _tools;

    void Start()
    {
        GetPins();
        GetTools();
    }


    public void ResetLock() 
    { 
        foreach (var pin in _pins) { pin.ResetPin(); }
        SetStartPositions();
    }

    public void CheckLock()
    {
        foreach (Pin pin in _pins)
        {
            if (pin.State == PinState.IncorrectPosition) return;
        }
        OnUnlock?.Invoke();
    }

    private void GetPins()
    {
        var pinsObjects = GameObject.FindGameObjectsWithTag(Tags.Pin.ToString());
        _pins = new Pin[pinsObjects.Length];

        for (int i = 0; i < pinsObjects.Length; i++)
        {
            _pins[i] = pinsObjects[i].GetComponent<Pin>();
            _pins[i].OnPinObjectInitialized += SetStartPositions;
        }
    }

    private void GetTools()
    {
        var toolsObjects = GameObject.FindGameObjectsWithTag(Tags.Tool.ToString());
        _tools = new Tool[toolsObjects.Length];
        var dataForTools = InitialFactory.GetToolDtoList();

        for (int i = 0; i < toolsObjects.Length; i++)
        {
            _tools[i] = toolsObjects[i].GetComponent<Tool>();
            _tools[i].OnInteractionHappend += CheckLock;
            _tools[i].Name = toolsObjects[i].name.ToLower();
            _tools[i].Dto = dataForTools[i];
        };
    }

    private void SetStartPositions()
    {
        var dtoList = InitialFactory.GetStartPositionDtoList();
        var concreteDtoVersion = dtoList[new System.Random().Next(dtoList.Count - 1)];

        for (int i = 0; i < _pins.Length; i++)
        {
            _pins[i].CurrentPosition = concreteDtoVersion.Positions[i];
        }
    }

}

public enum Tags
{
    Pin,
    Tool
}
