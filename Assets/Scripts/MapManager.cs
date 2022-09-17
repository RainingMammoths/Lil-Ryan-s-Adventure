using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;
    [SerializeField] private TileBase[] trapTiles;    

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    public IEnumerator TriggerTrap(Vector3Int position, int trapTile, float time)
    {
        if (trapTile == 1)
        {
            yield return new WaitForSeconds(time);
            map.SetTile(position, trapTiles[1]);
            StartCoroutine(TriggerTrap(position, 2, 1f));
        }
        else if (trapTile == 2)
        {
            yield return new WaitForSeconds(time);
            map.SetTile(position, trapTiles[2]);
            StartCoroutine(TriggerTrap(position, 0, 3f));
        }
        else if (trapTile == 0)
        {
            yield return new WaitForSeconds(time);
            map.SetTile(position, trapTiles[1]);
            yield return new WaitForSeconds(0.5f);
            map.SetTile(position, trapTiles[0]);
        }
    }

    public TileData GetTileData(Vector3 position)
    {
        Vector3Int gridPosition = map.WorldToCell(position);
        //Debug.Log(gridPosition);
        TileBase checkedTile = map.GetTile(gridPosition);
        
        return dataFromTiles[checkedTile];
        
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            print("At position" + gridPosition + " there is a" + clickedTile);
        }*/
    }
}
