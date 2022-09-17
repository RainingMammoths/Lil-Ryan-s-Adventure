using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    private InputHandle inputScript_;
    // Start is called before the first frame update
    protected void Start()
    {
        inputScript_ = GetComponent<InputHandle>();
        inputScript_.OnMouseButtonLeftClick += OnMouseButtonLeftClick;
        inputScript_.OnKeyW = CreateMoveCommand;
        inputScript_.OnKeyA = CreateMoveCommand;
        inputScript_.OnKeyS = CreateMoveCommand;
        inputScript_.OnKeyD = CreateMoveCommand;
    }

    private Command CreateMoveCommand(Vector2 direction)
    {
        return new MoveCommand(direction)
        {
            Execute = () => MoveCommand(direction, GetComponent<MovementComponent>().Speed),
            Undo = () => MoveCommand(-direction, GetComponent<MovementComponent>().Speed)
        };
    }

    private void OnMouseButtonLeftClick(object sender, System.EventArgs e)
    {
        StartCoroutine(PerformAttack(transform.position, .5f));
    }
}
