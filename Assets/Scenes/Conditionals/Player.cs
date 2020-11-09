using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D r;
    public float speed;
    public Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vel.x = Input.GetAxisRaw("Horizontal")*speed;
        vel.y = Input.GetAxisRaw("Vertical") * speed;

        r.velocity = vel;
    }
}
