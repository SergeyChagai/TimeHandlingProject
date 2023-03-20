using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour, ITool
{
    public List<IPinAffectData> PinAffectDataList { get; set; }
    public event Action OnInteractionHappend;
    public string Name { get; set; }

    private ToolDTO _dto;
    public ToolDTO Dto
    {
        get => _dto;
        set
        {
            if (_pins == null) GetPins();
            _dto = value;
            PinAffectDataList = new List<IPinAffectData>();
            for (int i = 0; i < _pins.Length; i++)
            {
                PinAffectDataList.Add(new PinAffectData { Pin = _pins[i], AffectRange = _dto.AffectData[i] });
            }
        }
    }

    private Pin[] _pins;

    public void Use()
    {
        foreach (IPinAffectData pinAffectData in PinAffectDataList)
        {
            pinAffectData.Pin.CurrentPosition += pinAffectData.AffectRange;
        }
        OnInteractionHappend?.Invoke();
    }

    void Start()
    {
        GetPins();
    }

    private void GetPins()
    {
        var pinsObjects = GameObject.FindGameObjectsWithTag(Tags.Pin.ToString());
        _pins = new Pin[pinsObjects.Length];

        for (int i = 0; i < pinsObjects.Length; i++)
        {
            _pins[i] = pinsObjects[i].GetComponent<Pin>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
