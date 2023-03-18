using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPinAffectData
{
    IPin Pin { get; set; }
    int AffectRange { get; set; }
}
