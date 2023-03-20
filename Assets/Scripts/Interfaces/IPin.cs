using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPin
{
    PinState State { get; }
    PositionsRange PositionsRange { get; }
    int CorrectPosition { get; }
    int CurrentPosition { get; set; }
}
