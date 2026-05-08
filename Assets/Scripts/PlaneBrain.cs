using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneBrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int coordinateX;
    private int coordinateZ;
    public bool exit = false;
    void Start()
    {
        coordinateX = (int)this.transform.position.x / 10;
        coordinateZ = (int)this.transform.position.z / 10;
        gameObject.name = coordinateX + "," + coordinateZ;
        // (0,0) -> (1,0) , (0,1)
        // for ( i  = 0 ; i < 4 ; i++)
        // { find (0, k +1) find (0, k - 1) find (k - 1, 0) find (k + 1, 0) }
    }
    // STEP 2
    // player centered on plane
    // player wants to go east --> the player knows east is 0,1 --> player is teleported to center of 0,1

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Planest");
    }
}
