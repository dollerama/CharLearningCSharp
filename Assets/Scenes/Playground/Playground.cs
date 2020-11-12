using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playground : MonoBehaviour
{
    public Text iT;

    public int getI()
    {
        int ret = 0;
        if (int.TryParse(iT.text, out ret))
            return ret;
        else
            return 1;
    }

    public void codeToRun()
    {
        examples.loops5(getI());
    }
}

public static class Util
{
    public static string ArrToStr<T>(T[] input)
    {
        string ret = "";
        for(int i=0; i < input.Length; i++)
        {
            if(i!=input.Length-1) ret += $"[{input[i]}], ";
            else ret += $"[{input[i]}]";
        }
        return ret;
    }
}

public static class examples
{
    public static void variables1() //types
    {
        double piD = Mathf.PI;
        float piF = Mathf.PI;

        int maxI = 2147483647;
        long maxL = 9223372036854775807;

        string hello = "Hello World";
        char c = 'h';
        char[] cArray = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };

        bool b1 = false;
        bool b2 = true;

        Debug.Log($"Int:               {maxI}");
        Debug.Log($"Long:              {maxL}");
        Debug.Log($"Double:            {piD}");
        Debug.Log($"Float:             {piF}\n");

        Debug.Log($"Character:         {c}");
        Debug.Log($"String:            {hello}");
        Debug.Log($"Char Array:        {Util.ArrToStr<char>(cArray)}\n");

        Debug.Log($"Boolean:            {b1}+{b2}");
    }

    public static void variables2() //operators
    {
        int i1 = 10;
        int i2 = 20;

        Debug.Log($"i1: {i1}");
        Debug.Log($"i2: {i2}");
        Debug.Log($"i1+i2 = {i1+i2}");
        Debug.Log($"i1/i2 = {i1/i2}");
        Debug.Log($"i1*i2 = {i1*i2}");
        Debug.Log($"i1%i2 = {i1 % i2}");
        Debug.Log($"i1++ = {i1+1}");
    }

    public static void conditionals1(int tmp)
    {
        int i = tmp;
        Debug.Log($"i = {i}");

        if(i == 10)
        {
            Debug.Log("i equals 10");
        }
    }

    public static void conditionals2(int tmp)
    {
        int i = tmp;
        Debug.Log($"i = {i}");

        if (i == 10)
        {
            Debug.Log("i equals 10");
        }
        else
        {
            Debug.Log("i does not equal 10");
        }
    }

    public static void conditionals3(int tmp)
    {
        int i = tmp;
        Debug.Log($"i = {i}");

        switch(i)
        {
            case 0: Debug.Log("i equals 0"); break;
            case 1: Debug.Log("i equals 1"); break;
            case 2: Debug.Log("i equals 2"); break;
            case 3: Debug.Log("i equals 3"); break;
            case 4: Debug.Log("i equals 4"); break;
            case 5: Debug.Log("i equals 5"); break;
        }
    }

    public static void conditionals4(int tmp)
    {
        int i = tmp;
        Debug.Log($"i = {i}");

        if (i%2 == 0)
        {
            Debug.Log("i is even");
        }
        else
        {
            Debug.Log("i is odd");
        }
    }

    public static void loops1(int tmp)
    {
        for(int i=0; i < tmp; i++)
        {
            Debug.Log(i);
        }
    }

    public static void loops2(int tmp)
    {
        for (int i = tmp; i > 0; i--)
        {
            Debug.Log(i);
        }
    }

    public static void loops3(int tmp)
    {
        for (int i = 0; i < tmp; i++)
        {
            for (int j = 0; j < tmp; j++)
            {
                Debug.Log($"i: {i}, j: {j}");
            }
        }
    }

    public static void loops4(int tmp)
    {
        int r = Random.Range(0, tmp + 1);
        while (r != tmp)
        {
            r = Random.Range(0, tmp + 1);
            Debug.Log(r);
        }
    }

    public static void loops5(int tmp)
    {
        int r = Random.Range(0, tmp + 1);
        do
        {
            r = Random.Range(0, tmp + 1);
            Debug.Log(r);
        } while (r != tmp);
    }

    public static void loopsPH(int tmp)
    {
        string output = "";
        int rows = tmp;

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                output += "*";
            }
            Debug.Log(output);
            output = "";
        }
    }

    public static void loopsPF(int tmp)
    {
        string output = "";
        int rows =tmp;
        int k = 0;

        for (int i = 1; i <= rows; i++)
        {
            k = 0;
            for (int space = 1; space <= rows - i; space++)
            {
                output += " ";
            }

            while (k != (2*i-1))
            {
                output += "*";
                k++;
            }

            Debug.Log(output);
            output = "";
        }
    }
}
