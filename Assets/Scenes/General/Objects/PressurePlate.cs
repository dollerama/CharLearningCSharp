using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class PressurePlate : MonoBehaviour
{
    public GameObject main;
    public GameObject inside;
    public Color insideColor;

    public bool pressed;

    public bool elseSwitch;

    // Start is called before the first frame update
    void Start()
    {
        insideColor = inside.GetComponent<Rectangle>().Color;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            main.transform.localPosition = Vector3.Lerp(main.transform.localPosition, Vector3.zero, Time.deltaTime*5);
            inside.GetComponent<Rectangle>().Color = Color.red;
        }
        else
        {
            main.transform.localPosition = Vector3.Lerp(main.transform.localPosition, Vector3.up * .12f, Time.deltaTime * 5);
            if(!elseSwitch) inside.GetComponent<Rectangle>().Color = Color.Lerp(inside.GetComponent<Rectangle>().Color, insideColor, Time.deltaTime*5);
            else inside.GetComponent<Rectangle>().Color = Color.Lerp(inside.GetComponent<Rectangle>().Color, new Color(0, Mathf.Cos(Time.time*2), Mathf.Sin(Time.time*3), 1), Time.deltaTime * 5);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pressed = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
    }
}
