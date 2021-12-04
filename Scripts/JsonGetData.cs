using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class JsonGetData : MonoBehaviour
{
    public RootArray rootArray;

    public Text textJson;

    string getURL = "https://hotelapi.eastus.cloudapp.azure.com/";

    public Color jsonColor;
    public string jsonNumber;

    public Texture requestTextureColor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest());
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator GetRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(getURL))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            var jsonText = webRequest.downloadHandler.text;

            rootArray = JsonUtility.FromJson<RootArray>("{\"root\":" + jsonText + "}");

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received: " + webRequest.downloadHandler.text);
                    break;
            }

            //jsonColor = rootArray.root[0].randomColor;  

            jsonNumber = rootArray.root[0].percentage;
        }
    }

    IEnumerator Texture_Image(string MediaURL)
    {
        UnityWebRequest requestTexture = UnityWebRequestTexture.GetTexture(MediaURL);

        yield return requestTexture.SendWebRequest();

        if (requestTexture.isNetworkError || requestTexture.isHttpError)
        {
            Debug.Log(requestTexture.error);
        }
        else
        {
            requestTextureColor = ((DownloadHandlerTexture)requestTexture.downloadHandler).texture as Texture2D;
            //Sprite tempSprite = Sprite.Create(requestTextureColor, new Rect(0.0f, 0.0f, requestTextureColor.width, requestTextureColor.height), Vector2.zero);
        }

    }


    [System.Serializable]
    public class RootArray
    {
        public Root[] root;
    }

    [System.Serializable]
    public class Root
    {
        public string randomColor;
        public string percentage;
    }

}
