using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Imagejson 
{
    public string originalPrompt;
    public string gptPrompt;
    public string imageName;
    public string imageURL;
    public static Imagejson CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Imagejson>(jsonString);
    }
    public void printInfo()
    {
        Debug.Log(originalPrompt + "\n, " + gptPrompt + "\n, " + imageName + "\n, " + imageURL);
    }
}
