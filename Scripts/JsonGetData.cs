using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class JsonGetData : MonoBehaviour
{
    GameManager gameManager;
    //Layout layout;

    public RootArray rootArray;

    public Text textJson;

    string getURL = "https://hotelapi.eastus.cloudapp.azure.com/";

    public GameObject cubeTexturePrefab;

    public string jsonColor;
    public string jsonNumber;

    public string jsonColor2;
    public string jsonNumber2;
    // Start is called before the first frame update
    void Start()
    {
        //layout = FindObjectOfType<Layout>();
        gameManager = FindObjectOfType<GameManager>();
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

            string jsonText = webRequest.downloadHandler.text;

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

            //for (int i = 0; i < rootArray.root[0].randomColor.Length; i++)
            //{
                //Debug.Log("Hello World");
                //GameObject temp = Instantiate(cubeTexturePrefab);
                //jsonNumber = rootArray.root[0].percentage;
                jsonColor = rootArray.root[0].randomColor;

                //jsonNumber2 = rootArray.root[1].percentage;
                //jsonColor2 = rootArray.root[1].randomColor;
            //gameManager = temp.GetComponent<GameManager>();
            //layout.cube2Obj.name = jsonNumber;

            //cubeTexturePrefab.name = jsonNumber;
                //gameManager.jsonNumber = rootArray.root[0].percentage;
                //jsonColor = rootArray.root[0].randomColor;
                //jsonNumber = rootArray.root[0].percentage;
                //cubeTexturePrefab = jsonColor;
                //cubeTexturePrefab.GetComponent<Color>() = jsonColor.ToString;
                //cubeTexturePrefab.name = jsonNumber;

                //StartCoroutine(Texture_Image(jsonColor));
            //}

            //for (int i = 0; i < rootArray.root[0].percentage.Length; i++)
            //{

                jsonNumber = rootArray.root[0].percentage;
                //cubeTexturePrefab.name = jsonColor;
                //cubeTexturePrefab.name = jsonNumber;
                //StartCoroutine(Texture_Image(jsonColor));
            //}
        }
    }

    //IEnumerator Texture_Image(string MediaURL)
    //{
    //    UnityWebRequest requestTexture = UnityWebRequestTexture.GetTexture(MediaURL);

    //    yield return requestTexture.SendWebRequest();

    //    if (requestTexture.isNetworkError || requestTexture.isHttpError)
    //    {
    //        Debug.Log(requestTexture.error);
    //    }
    //    else
    //    {
    //        cubeTexturePrefab.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)requestTexture.downloadHandler).texture;
    //        Debug.Log("Cube Color");
    //    }

    //}


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
