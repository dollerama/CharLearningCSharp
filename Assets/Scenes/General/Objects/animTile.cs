using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class animTile : MonoBehaviour
{
    public bool animate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            float t = Time.time * 10;

            float p = Mathf.PerlinNoise((transform.position.x + t) / 20.0f, (transform.position.y + t) / 20.0f);

            this.GetComponent<Rectangle>().Color = new Color(1 - p + (Mathf.Sin(transform.position.y * .25f)), p, 1 - p, p);
        }
    }
}
