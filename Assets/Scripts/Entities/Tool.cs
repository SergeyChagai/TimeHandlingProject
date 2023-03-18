using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour, ITool
{
    public List<IPinAffectData> PinAffectDataList { get; private set;}

    public void Use()
    {
        foreach (IPinAffectData pinAffectData in PinAffectDataList)
        {
            pinAffectData.Pin.CurrentState += pinAffectData.AffectRange;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
