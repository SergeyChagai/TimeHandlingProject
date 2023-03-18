using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITool
{
    List<IPinAffectData> PinAffectDataList { get; }
    void Use();
}
