using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void codeToRun()
    {
        string output = "";
        int rows = 5;
        int k = 0;

        //for (int i = 1; i <= rows; i++)
        //{
        //    for (int j = 1; j <= i; j++)
        //    {
        //        output += "*";
        //    }
        //    Debug.Log(output);
        //    output = "";
        //}

        for (int i = 1; i <= rows; i++)
        {
            k = 0;
            for (int space = 1; space <= rows - i; space++)
            {
                output += " ";
            }

            while (k != 2 * i - 1)
            {
                output += "*";
                k++;
            }
           
            Debug.Log(output);
            output = "";
        }
        
    }
}
