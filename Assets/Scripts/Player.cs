using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    private InputHandle inputScript_;
    private VisualComponent visualComponentScript_;

    private LayerMask layerMask_;
    [SerializeField] float dialogueDistance;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        layerMask_ = LayerMask.GetMask("Interactable");
        inputScript_ = GetComponent<InputHandle>();
        visualComponentScript_ = GetComponent<VisualComponent>();
        inputScript_.OnMouseButtonLeftClick += OnMouseButtonLeftClick;
        inputScript_.OnEButtonClick += OnInteract;
        inputScript_.OnKeyW = CreateMoveCommand;
        inputScript_.OnKeyA = CreateMoveCommand;
        inputScript_.OnKeyS = CreateMoveCommand;
        inputScript_.OnKeyD = CreateMoveCommand;
    }

    protected override void OnHit()
    {
        StartCoroutine(visualComponentScript_.BlinkAlpha(0, .75f));
    }

    protected void OnInteract(object sender, System.EventArgs e)
    {
        // Check for NPCs
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        var direction = worldMousePosition - transform.position;
        var results = Physics2D.Raycast(transform.position, direction, dialogueDistance,layerMask_);
        if (results.collider != null)
        {
            Debug.Log(results.transform.gameObject);
            Debug.Log(direction.magnitude);
            var dialogueScript = results.collider?.gameObject?.GetComponent<DialogueComponent>();
            dialogueScript.Dialogue(0, gameObject);
            Debug.DrawLine(transform.position, worldMousePosition, Color.red, 5f);
        }
        else
        {
            Debug.DrawLine(transform.position, worldMousePosition, Color.blue, 5f);
        }
        // check for items
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
