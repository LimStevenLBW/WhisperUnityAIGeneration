using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImageDownloaderScreen : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public ImagePrompt imagePrompt;
    public InputFieldPrompt inputFieldPrompt;


    public void setImage(string url)
    {
        StartCoroutine(DownloadImage(url));

    }
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        imagePrompt.StopLoadingText();

        inputFieldPrompt.activated = false;
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            //Texture.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            //texture=SetTexture("Image", ((DownloadHandlerTexture)request.downloadHandler).texture);

            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            var mat = new Material(Shader.Find("UI/Default"));
            mat.mainTexture = myTexture;
            meshRenderer.material.mainTexture = myTexture;
        }
    }   
}
