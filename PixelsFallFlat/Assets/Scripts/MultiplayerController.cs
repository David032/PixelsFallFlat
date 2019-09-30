using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetJoystickNames().Length == 2)
        {
            Player2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
