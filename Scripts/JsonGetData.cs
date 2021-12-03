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
        public double percentage;
    }

}
