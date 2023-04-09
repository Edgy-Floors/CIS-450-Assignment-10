using UnityEngine;
using System.Collections;

[System.Serializable]
public static class StaticClass
{
    public static string textToOutput;
    public static int number = 41;

    public static void OutputTextToConsole()
    {
        textToOutput = "This is a static class. It is accessible from anywhere " +
                    "and CANNOT be instantiated or attached to GameObjects.  \n" +
                            "This static class does NOT extend MonoBehavior.  " +
                            "Yay!  " + number;
        Debug.Log(textToOutput);
    }



}
