using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    private InputHandle inputScript_;
    private VisualComponent visualComponentScript_;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        inputScript_ = GetComponent<InputHandle>();
        visualComponentScript_ = GetComponent<VisualComponent>();
        inputScript_.OnMouseButtonLeftClick += OnMouseButtonLeftClick;
        inputScript_.OnKeyW = CreateMoveCommand;
        inputScript_.OnKeyA = CreateMoveCommand;
        inputScript_.OnKeyS = CreateMoveCommand;
        inputScript_.OnKeyD = CreateMoveCommand;
    }

    protected override void OnHit()
    {
        StartCoroutine(visualComponentScript_.BlinkAlpha(0, .75f));
    }

    private Command CreateMoveCommand(Vector2 direction)
    {
        return new MoveCommand(direction)
        {
            Execute = () => Move(direction, GetComponent<MovementComponent>().Speed),
            Undo = () => Move(-direction, GetComponent<MovementComponent>().Speed)
        };
    }

    private void OnMouseButtonLeftClick(object sender, System.EventArgs e)
    {
        StartCoroutine(Attack(transform.position, .5f));
    }

    protected override void Die(object sender, EventArgs e)
    {
        // Reload level
    }
}
