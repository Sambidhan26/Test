using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{

    JsonGetData jsonData;

    //public Transform cubesPrefabs;
    public Transform cubesPrefabs;


    //public GameObject cube2Obj;
    [SerializeField]
    int height;
    [SerializeField]
    int width;


   //public Color cubeColor;
   // string colorString;
    //int r;
    // Start is called before the first frame update
    void Start()
    {
        jsonData = FindObjectOfType<JsonGetData>();
        CreateGridLayout();
    }

    // Update is called once per frame
    void Update()
    {
        //cubesPrefabs2.transform.position = cubesPrefabs.position;
    }

    public void CreateGridLayout()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i, 0, j);

                //Transform cubeObj = Instantiate(cubesPrefabs, worldPosition, Quaternion.identity);
                cubesPrefabs = Instantiate(cubesPrefabs, worldPosition, Quaternion.identity);
                //for(int a = 0; a < jsonData.rootArray.root.Length; a ++)
                //{
                
                 //colorString = jsonData.rootArray.root[0].randomColor;   //cube2Obj.name = jsonData.rootArray.root[0].percentage;
             
                 //ColorUtility.TryParseHtmlString(colorString, out cubeColor);
                 //cubesPrefabs.GetComponent<Renderer>().material.color = cubeColor;
                //}

            }
        }

        //***********************************Tried Diamond Layout*************************************
        //for (int i = 0; i <= r; i++)
        //{

        //    Vector3 worldPosition1 = new Vector3(i, 0, 0);

        //    for (int j = 1; j <= r - i; j++)
        //        Instantiate(cubesPrefabs, worldPosition1, Quaternion.identity);
        //    for (int j = 1; j <= 2 * i - 1; j++)
        //    {
        //        Vector3 worldPosition2 = new Vector3(0, 0, j);
        //        Instantiate(cubesPrefabs, worldPosition2, Quaternion.identity);
        //    }
        //}

        //for (int i = r - 1; i >= 1; i--)
        //{
        //    for (int j = 1; j <= r - i; j++)
                //
                //
                //
        //        for (j = 1; j <= 2 * i - 1; j++);


        //}
        //**********************************************************************************************************
    }
}
