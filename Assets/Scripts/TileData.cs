using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public float speedCost; // Speed up, Slow Down
    public bool isWalkable; // Wall, Ground
    public bool isTrap; // Trap
}
