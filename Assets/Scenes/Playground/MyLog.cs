using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyLog : MonoBehaviour
{
    string myLog;
    public Text logText;
    Queue myLogQueue = new Queue();

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
            if (n > myLogQueue.Count)
            {
                if(n%2 == 0)
                    myLog += $"<color=grey>{mylog}</color>";
                else
                    myLog += $"{mylog}";
            }
            n++;
        }
    }

    public void clear()
    {
        myLog = "";
        myLogQueue.Clear();
    }

    private void Update()
    {
        logText.text = myLog;
    }
}