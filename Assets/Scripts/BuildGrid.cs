using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildGrid : MonoBehaviour
{
    public GameObject Planest;
    void Start ()
    {
        for(int row = 0; row < 4; row++) 
        {
            for (int column = 0; column < 4; column++)
            {
                Instantiate(Planest, new Vector3(row * 10, 0, column * 10), Quaternion.identity);
            }
        }
    }
}
