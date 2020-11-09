using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setVars : MonoBehaviour
{
    public Text boolean;
    public Text Integer;
    public Text FloatingPoint;

    public Toggle booleanT;
    public Slider IntegerT;
    public Slider FloatingPointT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(booleanT.isOn)
        {
            boolean.text = "True";
        }
        else
        {
            boolean.text = "False";
        }

        Integer.text = IntegerT.value.ToString();
        FloatingPoint.text = FloatingPointT.value.ToString("0.#");
    }
}
