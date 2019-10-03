using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelWDirt : MonoBehaviour
{

    public GameObject dirtHill;
    public GameObject shovel;
    public GameObject hiddenItem;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == shovel)
        {
            Instantiate(hiddenItem, transform.position + new Vector3(0f, 0f, 0f), new Quaternion());
            Destroy(this.gameObject);
        }
    }
}