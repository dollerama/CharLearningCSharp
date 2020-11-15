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
        examples.class4();
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

    public static void conditionals5(int tmp)
    {
        int i = tmp;
        Debug.Log($"i = {i}");

        if (i == 0)
        {
            Debug.Log("i is zero");
        }
        else if (i % 2 == 0)
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

    public static void loops6(int tmp)
    {
        if (tmp > 1)
        {
            int[] ia = new int[tmp];
            for (int i = 0; i < ia.Length; i++)
                ia[i] = i;

            int j = 0;
            foreach (int i in ia)
            {
                int r = Random.Range(j, ia.Length - 1);
                int i2 = i;
                ia[j] = ia[r];
                ia[r] = i2;
                j++;
            }

            foreach (int i in ia)
            {
                Debug.Log(i);
            }
        }
        else
        {
            Debug.Log("i too small");
        }
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

    public static void function1()
    {
        Debug.Log("Hi I'm your function code!");
    }

    public static int function2()
    {
        Debug.Log("I return an integer: 256.");
        return 256;
    }

    public static int function3(int tmp)
    {
        Debug.Log($"i = {tmp++}");
        return tmp;
    }

    public static void function4(ref int tmp)
    {
        Debug.Log($"i = {tmp++}");
    }

    public static void function3_4(int tmp)
    {
        //using a ref variable
        int r = tmp;
        examples.function4(ref r);
        Debug.Log($"Now i = {r}");

        //using return
        r = examples.function3(tmp);
        Debug.Log($"Now i = {r}");
    }

    public static void function5(int tmp = -256)
    {
        if(tmp == -256)
        {
            Debug.Log("Default");
        }
        else
        {
            Debug.Log($"i = {tmp}");
        }
    }

    public static void class1()
    {
        Jewel jwl = new Jewel(jColor.Ruby, jSize.Medium, jRarity.Uncommon);
        string value = string.Format("{0:n0}", jwl.getCashValue());

        Debug.Log($"This {jwl.getDiscript()} Jewel is worth ... $"+value);
    }

    public static void class2()
    {
        Jewel jwl = new Jewel();
        string value = string.Format("{0:n0}", jwl.getCashValue());

        Debug.Log($"This {jwl.getDiscript()} Jewel is worth ... $" + value);
    }

    public static void class3()
    {
        Character gobby = new Goblin("Tim", "Im and very smart and capable goblin");

        Debug.Log(gobby.Greet());
    }

    public static void class4()
    {
        Character hacker = new Hacker("Acid Wash", "I'm a vert smart and capable hack person");

        Debug.Log(hacker.Greet());
    }
}

public enum jColor
{
    White,
    Pink,
    Ruby,
    Emerald,
    Saphire
}

public enum jSize
{
    Small,
    Medium,
    Large
}

public enum jRarity
{
    Uncommon,
    Common,
    Rare
}

public class Jewel
{
    private jColor color;
    private jSize size;
    private jRarity rarity;

    public Jewel(jColor c, jSize s, jRarity r)
    {
        color = c; size = s; rarity = r;
    }

    public Jewel()
    {
        randomizeC();
        randomizeR();
        randomizeS();
    }

    public void randomizeS()
    {
        size = (jSize)Random.Range(0, 3);
    }

    public void randomizeR()
    {
        rarity = (jRarity)Random.Range(0, 3);
    }

    public void randomizeC()
    {
        color = (jColor)Random.Range(0, 5);
    }

    public string getDiscript()
    {
        string ret = "";

        switch (size)
        {
            case jSize.Small: ret += "small"; break;
            case jSize.Medium: ret += "medium"; break;
            case jSize.Large: ret += "large"; break;
        }

        switch (rarity)
        {
            case jRarity.Uncommon: ret += " uncommon"; break;
            case jRarity.Common: ret += " common"; break;
            case jRarity.Rare: ret += " rare"; break;
        }

        switch (color)
        {
            case jColor.Emerald: ret += " Emerald"; break;
            case jColor.Pink: ret += " Crystal"; break;
            case jColor.Ruby: ret += " Ruby"; break;
            case jColor.Saphire: ret += " Saphire"; break;
            case jColor.White: ret += " Ivory"; break;
        }

        return ret;
    }

    public int getCashValue()
    {
        int currenVal = 0;

        switch(size)
        {
            case jSize.Small: currenVal = 10000; break;
            case jSize.Medium: currenVal = 25000; break;
            case jSize.Large: currenVal = 50000; break;
        }

        switch(color)
        {
            case jColor.Emerald: currenVal += 5250; break;
            case jColor.Pink: currenVal += 2250; break;
            case jColor.Ruby: currenVal += 12575; break;
            case jColor.Saphire: currenVal += 17525; break;
            case jColor.White: currenVal += 7275; break;
        }

        switch (rarity)
        {
            case jRarity.Uncommon: currenVal = Mathf.RoundToInt(currenVal*0.75f); break;
            case jRarity.Common: currenVal = Mathf.RoundToInt(currenVal * 0.95f); break;
            case jRarity.Rare: currenVal = Mathf.RoundToInt(currenVal * 1.25f); break;
        }

        return currenVal;
    }
}

public abstract class Character
{
    public string name;
    public string greeting;

    public Character(string n, string g)
    {
        name = n;
        greeting = g;
    }

    public abstract string Greet();
}

public class Goblin : Character
{
    public Goblin(string n, string g) : base(n, g)
    {
        name = n;
        greeting = g;
    }

    public override string Greet()
    {
        return ($"{name} says {greeting}");
    }
}

public class Hacker : Character
{
    public Hacker(string n, string g) : base(n, g)
    {
        name = obfuscate(n);
        greeting = obfuscate(g);
    }

    private string obfuscate(string s)
    {
        string ret = s;
        char[] arrC = ret.ToCharArray();
        ret = "";

        int length = Random.Range(3, 5);

        for (int i = 0; i < length; i++)
        {
            int j = Random.Range(i+1, arrC.Length);
            char swap = arrC[i];
            arrC[i] = arrC[j];
            arrC[j] = swap;
            arrC[i] += '5';
        }

        foreach (char c in arrC)
        {
            ret += c;
        }

        return ret;
    }

    public override string Greet()
    {
        return ($"{name} says {greeting}");
    }
}
