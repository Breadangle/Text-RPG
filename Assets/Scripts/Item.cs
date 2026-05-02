using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int id;
    public string itemName;
    public int Value;
    public Sprite icon;
}


