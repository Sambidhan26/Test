using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{

    JsonGetData jsonData;

    //public Transform cubesPrefabs;
    public GameObject cubesPrefabs2;

    [SerializeField]
    int height;
    [SerializeField]
    int width;

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

    private void CreateGridLayout()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i, 0, j);

                //Transform cubeObj = Instantiate(cubesPrefabs, worldPosition, Quaternion.identity);
                GameObject cube2Obj = Instantiate(cubesPrefabs2, worldPosition, Quaternion.identity);
                for(int a = 0; a < jsonData.rootArray.root.Length; a ++)
                {
                    //cubesPrefabs2 = jsonData.rootArray.root[0].randomColor;
                }

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
