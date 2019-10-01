using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelWDirt : MonoBehaviour
{
    public GameObject dirtHill;
    public GameObject shovel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == shovel)
        {
            //Destroy(dirtHill.gameObject);
            //Destroy(this.gameObject);
        }
    }
}