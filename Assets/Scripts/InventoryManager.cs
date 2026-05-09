using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> ItemList = new List<Item>();
    public TextMeshProUGUI ItemDisplay;
    /*
    private void Awake()
    {
        Instance = Instance;
    }
    */

    public void Add (Item item)
    {
        ItemList.Add(item);
    }

    public void Remove (Item item)
    {
        ItemList.Remove(item);
    }

    public void playerInventory()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            ItemDisplay.text += i + " " + ItemList[i].name;
        }
    }
}
