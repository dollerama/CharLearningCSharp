using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public Vector3 newPos;
    public float period;
    public float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        newPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos.y = magnitude*Mathf.Sin(Time.time * period);

        this.transform.position = newPos;
    }
}
