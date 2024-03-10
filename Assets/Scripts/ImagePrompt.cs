using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImagePrompt : MonoBehaviour
{
    //public MeshRenderer renderer;
    public TextMeshPro textPrompt;

    private string loadingText = "Loading";

    public void StartLoadingText()
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadingTextRoutine());
    }

    public void StopLoadingText()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    IEnumerator LoadingTextRoutine()
    {
        int count = 0;
        string text = loadingText;
        while (true)
        {
            if (count >= 3)
            {
                text = loadingText;
                count = 0;
            }
            text += ".";
            yield return new WaitForSeconds(0.5f);
            textPrompt.SetText(text);
            count++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
