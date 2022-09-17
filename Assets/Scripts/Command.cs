using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public Action Execute { get; set; }
    public Action Undo { get; set; }
    /*public virtual void Execute(GameObject go)
    {

    }

    public virtual void Undo(GameObject go)
    {

    }
    */
}

class AttackCommand : Command
{
    public AttackCommand()
    {

    }

    /*public override void Execute(GameObject go)
    {
        //StartCouroutine(go.GetComponent<Actor>().PerformAttack(go.transform.position, .5f));
    }
    */
}

class MoveCommand : Command
{
    Vector2 direction_;
    public MoveCommand(Vector2 direction)
    {
        this.direction_ = direction;
    }
    /*public override void Execute(GameObject go)
    {
        go.GetComponent<Actor>().MoveCommand(direction_,go.GetComponent<MovementComponent>().Speed);
    }
    public override void Undo(GameObject go)
    {
        go.GetComponent<Actor>().MoveCommand(-direction_,go.GetComponent<MovementComponent>().Speed);
    }
    */
}
