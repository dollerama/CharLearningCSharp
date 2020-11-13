using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public static class str
{
    public static List<int> AllIndexesOf(this string str, string value)
    {
        List<int> indexes = new List<int>();
        for (int index = 0; ; index += value.Length)
        {
            index = str.IndexOf(value, index);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
    }
}

public class MyLog : MonoBehaviour
{
    public string myLog;
    public string myLog2;
    public Text logText;
    public Queue myLogQueue = new Queue();

    public bool loading;

    void Start()
    {
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    IEnumerator updateLog()
    {
        if(!loading && !myLog.Equals(myLog2) && myLog.Length > 1)
        {
            myLog2 = "";
            loading = true;
            List<int> ind = myLog.AllIndexesOf("\n");

            int j = 1;
            foreach(int i in ind)
            {
                if(j <= ind.Count) myLog2 += myLog.Substring(i, ind[j++]-i);
                yield return new WaitForEndOfFrame();
            }
        }
        yield return new WaitForEndOfFrame();
        loading = false;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        myLog = logString;
        string newString = "\n [" + type + "] : " + myLog;
        myLogQueue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            myLogQueue.Enqueue(newString);
        }
        myLog = string.Empty;
        int n = 0;
        foreach (string mylog in myLogQueue)
        {
            if (n > myLogQueue.Count - 20)
            {
                if (n % 2 == 0)
                    myLog += $"<color=grey>{mylog}</color>";
                else
                    myLog += $"{mylog}";
            }
            n++;
        }

        //StartCoroutine("updateLog");
    }

    public void clear()
    {
        myLog = "";
        myLog2 = "";
        myLogQueue.Clear();
    }

    private void Update()
    {
        

        logText.text = myLog;
    }
}