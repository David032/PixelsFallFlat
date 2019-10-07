using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    /// <summary>
    /// This is a little helper class so that crates can be detected easily
    /// </summary>
    public enum CrateSize 
    {
        Small,
        Large
    }

    public CrateSize Crate = CrateSize.Large;
}
