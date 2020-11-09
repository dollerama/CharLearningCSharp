using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed*Time.deltaTime);
    }
}
