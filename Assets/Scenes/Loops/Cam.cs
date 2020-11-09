using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float amount;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10), Time.deltaTime * 8);
    }

    public void Shake(float a, float d)
    {
        amount = a; duration = d;
        StartCoroutine("shakeCo");
    }

    IEnumerator shakeCo()
    {
        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            transform.position += Random.insideUnitSphere * amount;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
