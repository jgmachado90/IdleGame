using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldScrollable
{
    public float ScrollSpeed { get; set; }
    public void Scroll();

    public void Finished();
}
