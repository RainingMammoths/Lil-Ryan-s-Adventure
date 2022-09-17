using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public GameObject go;
    [SerializeField] private MapManager mapManagerScript_;

    public IEnumerator PerformAttack(Vector3 position, float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("attack");
        // Do a check for collision with objects to be hit
    }

    public void AttackCommand()
    {

    }

    public void MoveCommand(Vector2 direction, float speed)
    {
        Vector3 moveDelta = new Vector3(direction.x, direction.y, 0f) * speed * Time.fixedDeltaTime;
        //Debug.Log(mapManagerScript_ + " " + transform.position + " " + moveDelta);
        TileData tileData = mapManagerScript_.GetTileData(transform.position + moveDelta);
        if (tileData.isWalkable)
        {
            transform.position += moveDelta;
        }
        else
        {
            if (mapManagerScript_.GetTileData(transform.position + new Vector3(speed * direction.x * Time.fixedDeltaTime, 0, 0)).isWalkable)
                transform.position += new Vector3(moveDelta.x, 0f, 0f) * speed;
            if (mapManagerScript_.GetTileData(transform.position + new Vector3(0, speed * direction.y * Time.fixedDeltaTime, 0)).isWalkable)
                transform.position += new Vector3(0, moveDelta.y, 0f) * speed;
        }
        if (tileData.isTrap)
        {
            StartCoroutine(mapManagerScript_.TriggerTrap(Vector3Int.FloorToInt(transform.position + moveDelta), 1, 0f));
        }            
    }
}
