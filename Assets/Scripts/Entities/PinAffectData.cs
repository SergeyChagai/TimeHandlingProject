using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinAffectData : IPinAffectData
{
    public IPin Pin { get; set; }
    public int AffectRange { get; set; }
}
