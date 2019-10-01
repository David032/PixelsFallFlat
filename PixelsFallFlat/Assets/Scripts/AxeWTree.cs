using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWTree : MonoBehaviour
{
    public Transform spawnPos;

    public GameObject tree;
    public GameObject axe;
    public GameObject trunk;
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
        if (collision.gameObject == axe)
        {
            //Destroy(tree.gameObject);
            //Destroy(this.gameObject);
            //Instantiate(trunk, spawnPos.position, spawnPos.rotation);
        }
    }
}
