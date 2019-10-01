using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelWDirt : MonoBehaviour
{
    public GameObject dirtHill;
    public GameObject shovel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == shovel)
        {
            //Destroy(dirtHill.gameObject);
            //Destroy(this.gameObject);
        }
    }
}