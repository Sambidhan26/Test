using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeScript : MonoBehaviour
{
    JsonGetData jsonData;

    public Color color1;
    public Text percentageString;
    public string colorString;
    //Renderer canvas;
    // Start is called before the first frame update
    void Start()
    {
        jsonData = FindObjectOfType<JsonGetData>();
        //this.gameObject.GetComponent<Renderer>().material.color = colorString.text;

        //canvas = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        percentageString.text = jsonData.rootArray.root[0].percentage;
        percentageString.transform.position = this.gameObject.transform.position;


        colorString = jsonData.rootArray.root[0].randomColor;
        ColorUtility.TryParseHtmlString(colorString, out color1);

        gameObject.GetComponent<Renderer>().material.color = color1;
    }
}
