using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API_Manager : MonoBehaviour
{
    private string JsonString;
    private string APILink;
    public ImageDownloaderScreen DLImage;
    public ImagePrompt imagePrompt;
    // Start is called before the first frame update
    void Start()
    {
        APILink = "https://robin-server.onrender.com";
    }
   
    public void RequestImage(string prompt)
    {
        string uri = APILink + "/robin/" + prompt;
        StartCoroutine(GetRobinAPIRequest(uri));
    }
    // Update is called once per frame
    
    void Update()
    {
        
    }
    IEnumerator GetRobinAPIRequest(string uri)
    {
        imagePrompt.StartLoadingText();
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();
      
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                break;
            case UnityWebRequest.Result.ProtocolError:
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                JsonString = webRequest.downloadHandler.text;
                Imagejson json = Imagejson.CreateFromJSON(JsonString);

                json.printInfo();
                DLImage.setImage(json.imageURL);
                break;
        }

    }

}
