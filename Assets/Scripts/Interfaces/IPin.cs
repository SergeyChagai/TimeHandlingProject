using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPin
{
    StatesRange StatesRange { get; }
    int CorrectState { get; }
    int CurrentState { get; set; }
}
