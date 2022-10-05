using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set;}

    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;
    [SerializeField] private List<TrapTileData> trapTiles;
    private Dictionary<TrapState, TrapTileData> stateToTileData;
    //[SerializeField] private TileBase[] trapTiles;

    public bool IsDifferentTiles(Vector3Int position1, Vector3Int position2)
    {
        var cell1Bounds = map.GetBoundsLocal(position1);
        var cell2Bounds = map.GetBoundsLocal(position2);
        return cell1Bounds == cell2Bounds;
    }

    private IEnumerator TriggerTrap(Vector3Int position)
    {
        yield return new WaitForSeconds(.5f);
        var tileBase = stateToTileData[TrapState.Triggered].tiles.First();
        map.SetTile(position, tileBase);
        yield return new WaitForSeconds(.5f);
        tileBase = stateToTileData[TrapState.Deployed].tiles.First();

        map.SetTile(position, tileBase);
        yield return new WaitForSeconds(3f);
        tileBase = stateToTileData[TrapState.Triggered].tiles.First();
        map.SetTile(position, tileBase);
        yield return new WaitForSeconds(.5f);
        tileBase = stateToTileData[TrapState.Armed].tiles.First();
        map.SetTile(position, tileBase);
    }

    public TileData SteppedOnTile(Vector3Int position, GameObject go)
    {
        
        var tileBase = map.GetTile(position);
        var tileData = dataFromTiles[tileBase];
        if (tileData is TrapTileData trapTileData)
        {
            if (trapTileData.trapState == TrapState.Armed)
                StartCoroutine(TriggerTrap(position));
        }
        return tileData;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        stateToTileData = trapTiles.ToDictionary(x => x.trapState);
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
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
