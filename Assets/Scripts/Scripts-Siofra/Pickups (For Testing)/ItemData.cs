using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemPickup", order = 3)]

public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
