using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWTree : MonoBehaviour
{ 

    public GameObject tree;
    public GameObject axe;
    public GameObject trunk;

    void FixedUpdate()
    {
        axe = GameObject.Find("axe");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "axe(Clone)" ||collision.gameObject == axe)
        {
            Debug.Log("Stuff");
            Instantiate(trunk, transform.position + new Vector3(0.3f, 0f, 0f), new Quaternion());
            Destroy(this.gameObject);
        }
        Debug.Log("Other Stuff");
    }
}
