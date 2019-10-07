using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHandler : MonoBehaviour
{
    /// <summary>
    /// This is a little helper class so that pipes can be detected easily
    /// </summary>
    public enum PipeSize
    {
        Half,
        Full
    }

    public PipeSize Pipe = PipeSize.Full;
}
