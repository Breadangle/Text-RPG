using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string playerGridPosition;
    private Boolean PositionsHaveBeenSet = false;
    private Boolean BattleOff = true;
    private GameObject north;
    private GameObject south;
    private GameObject east;
    private GameObject west;
    void Start()
    {

        // (0,0) -> (1,0) , (0,1)
        // for ( i  = 0 ; i < 4 ; i++)
        // { find (0, k +1) find (0, k - 1) find (k - 1, 0) find (k + 1, 0) }

        // STEP 2
        // player centered on plane
        // player wants to go east --> the player knows east is 0,1 --> player is teleported to center of 0,1
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        GameObject currentGrid;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            // sets current grid of player
            playerGridPosition = hit.collider.name;
            currentGrid = GameObject.Find(playerGridPosition);
            //print("current player position is " + playerGridPosition);
            if (!(playerGridPosition.Equals("Planest(Clone)")))
            {
                transform.position = new Vector3(currentGrid.transform.position.x, currentGrid.transform.position.y + 1, currentGrid.transform.position.z);
                //transform.rotation = Quaternion.identity;
                // finds the other viable locations for the player to move to
                string[] tempCoord = playerGridPosition.Split(',');
                //print(currentGrid);
                //print("FLAG 0: " + tempCoord.Length);
                //print("FLAG 1:" + tempCoord[0] + " FLAG 2: " + tempCoord[1]);

                string tempCoordx = tempCoord[0];
                string tempCoordz = tempCoord[1];
                int tempX = int.Parse(tempCoordx);
                int tempZ = int.Parse(tempCoordz);

                north = FindGrid(tempX, tempZ + 1);
                south = FindGrid(tempX, tempZ - 1);
                east = FindGrid(tempX + 1, tempZ);
                west = FindGrid(tempX - 1, tempZ);

                PositionsHaveBeenSet = true;

                //print(north + " " + south + " " + east + " " + west);
            }
        }
        else
        {
            print("oops, the player didnt start over a viable grid tile");
        }

        if (PositionsHaveBeenSet && BattleOff)
        {
            // move north
            try
            {
                print("Before " + this.transform.eulerAngles.y);
                if (this.transform.eulerAngles.y < 1)
                {
                    print("After " + this.transform.eulerAngles.y);
                    if (Keyboard.current.wKey.wasPressedThisFrame)
                    {
                        print("move north " + north);
                        transform.position = new Vector3(north.transform.position.x, north.transform.position.y + 1, north.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                    else if (Keyboard.current.sKey.wasPressedThisFrame)
                    {
                        print("move south");
                        transform.position = new Vector3(south.transform.position.x, south.transform.position.y + 1, south.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                }
                else if(this.transform.eulerAngles.y < 91)
                {
                    print("does this ever get called");
                    if (Keyboard.current.wKey.wasPressedThisFrame)
                    {
                        print("move east");
                        transform.position = new Vector3(east.transform.position.x, east.transform.position.y + 1, east.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                    else if (Keyboard.current.sKey.wasPressedThisFrame)
                    {
                        print("move west");
                        transform.position = new Vector3(west.transform.position.x, west.transform.position.y + 1, west.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                }
                else if (this.transform.eulerAngles.y < 181)
                {
                    if (Keyboard.current.wKey.wasPressedThisFrame)
                    {
                        print("move south");
                        transform.position = new Vector3(south.transform.position.x, south.transform.position.y + 1, south.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                    else if (Keyboard.current.sKey.wasPressedThisFrame)
                    {
                        print("move north " + north);
                        transform.position = new Vector3(north.transform.position.x, north.transform.position.y + 1, north.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                }
                else if (this.transform.eulerAngles.y < 271)
                {
                    if (Keyboard.current.wKey.wasPressedThisFrame)
                    {
                        print("move west");
                        transform.position = new Vector3(west.transform.position.x, west.transform.position.y + 1, west.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                    else if (Keyboard.current.sKey.wasPressedThisFrame)
                    {
                        print("move east");
                        transform.position = new Vector3(east.transform.position.x, east.transform.position.y + 1, east.transform.position.z);
                        PositionsHaveBeenSet = false;
                    }
                }

                if (Keyboard.current.dKey.wasPressedThisFrame)
                {
                    //print("move east");
                    //transform.position = new Vector3(east.transform.position.x, east.transform.position.y + 1, east.transform.position.z);
                    //PositionsHaveBeenSet = false;
                    this.transform.eulerAngles = new Vector3(
                    this.transform.eulerAngles.x,
                    this.transform.eulerAngles.y + 90,
                    this.transform.eulerAngles.z );
                }
                else if (Keyboard.current.aKey.wasPressedThisFrame)
                {
                    //print("move west");
                    //transform.position = new Vector3(west.transform.position.x, west.transform.position.y + 1, west.transform.position.z);
                    //PositionsHaveBeenSet = false;
                    this.transform.eulerAngles = new Vector3(
                    this.transform.eulerAngles.x,
                    this.transform.eulerAngles.y - 90,
                    this.transform.eulerAngles.z);
                }
            }
            catch
            {
                print("Movement is Likely Out of Bounds");
            }
        }

    }

    void FixedUpdate()
    {
        
    }

    GameObject FindGrid(int x, int z)
    {
        string name = x + "," + z;
        if (name != null)
        {
            return GameObject.Find(name);
        }
        else 
        {
            return null;
        }
    }
}
