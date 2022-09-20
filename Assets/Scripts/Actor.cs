using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public GameObject go;
    [SerializeField] private MapManager mapManagerScript_;
    private HealthComponent healthScript_;
    public event EventHandler OnAttack;
    public TileData CurrentTile { get; set; }

    private void FixedUpdate()
    {
        var prevTile = CurrentTile;
        CurrentTile = mapManagerScript_.GetTileData(Vector3Int.FloorToInt(transform.position));
        var trapCurrentTile = CurrentTile as TrapTileData;
        var trapPrevTile = prevTile as TrapTileData;

        var isCurrentTrapTile = trapCurrentTile != null;

        var isPrevTrapTile = trapPrevTile != null;

        var isCurrentTrapDeployed = isCurrentTrapTile && trapCurrentTile.trapState == TrapState.Deployed;

        var isPrevTrapDeployed = isPrevTrapTile && trapPrevTile.trapState == TrapState.Deployed;

        var isHit = isCurrentTrapDeployed && !isPrevTrapDeployed;
        if (isHit)
        {
            healthScript_.AddHealth(-25);
            OnHit();
        }
    }


    //public Vector3 direction;

    protected virtual void Start()
    {
        healthScript_ = GetComponent<HealthComponent>();
        healthScript_.OnDeath += Die;
    }

    public IEnumerator Attack(Vector3 position, float time)
    {
        yield return new WaitForSeconds(time);
        OnAttack?.Invoke(this, EventArgs.Empty);
        Debug.Log("swish swoosh");
        // Do a check for collision with objects to be hit
    }

    protected virtual void Die(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }

    protected virtual void OnHit()
    {
        
    }

    public void Move(Vector2 direction, float speed)
    {
        Vector3 moveDelta = new Vector3(direction.x, direction.y, 0f) * speed * Time.fixedDeltaTime;
        if (direction.x != 0 && direction.y != 0)
        {
            Debug.DrawLine(transform.position, new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z), Color.white);
            Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + direction.y, transform.position.z), Color.white);
        }
        else if (direction.x != 0)
        {
            Debug.DrawLine(transform.position, new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z), Color.white);
        }
        else if (direction.y != 0)
        {
            Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + direction.y, transform.position.z), Color.white);
        }
        TileData tileData = mapManagerScript_.SteppedOnTile(Vector3Int.FloorToInt(transform.position + moveDelta), gameObject);
        
        if (tileData.isWalkable)
        {
            transform.position += moveDelta;
        }
        else
        {
            if (mapManagerScript_.GetTileData(transform.position + new Vector3(speed * direction.x * Time.fixedDeltaTime, 0, 0)).isWalkable)
            {
                transform.position += new Vector3(moveDelta.x, 0f, 0f) * speed;
            }
                
            if (mapManagerScript_.GetTileData(transform.position + new Vector3(0, speed * direction.y * Time.fixedDeltaTime, 0)).isWalkable)
                transform.position += new Vector3(0, moveDelta.y, 0f) * speed;
        }
    }
}
