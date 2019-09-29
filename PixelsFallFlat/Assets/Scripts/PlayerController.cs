using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 9.81f;

    Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");        

        Vector2 direction = new Vector2(h, v);

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle * -1, Vector3.forward);
        }

        //transform.Translate(direction / 50);
        playerBody.velocity = direction;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Movable")
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            collision.gameObject.transform.parent.SetParent(this.transform);
        }
    }
}
