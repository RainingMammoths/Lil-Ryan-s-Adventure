using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHandle : MonoBehaviour
{ 
    public Func<Vector2, Command> OnKeyW { get; set; }
    public Func<Vector2, Command> OnKeyS { get; set; }
    public Func<Vector2, Command> OnKeyA { get; set; }
    public Func<Vector2, Command> OnKeyD { get; set; }
    public event EventHandler OnMouseButtonLeftClick;
    public event EventHandler OnEButtonClick;
    LinkedList<Command> commandsPast = new LinkedList<Command>();
    LinkedList<Command> commandsFuture = new LinkedList<Command>();

    void AddCommand(LinkedList<Command> list, Command c)
    {
        if (commandsFuture.Any()) commandsFuture.Clear();
        list.AddFirst(c);
        if (list.Count > 500)
        {
            list.RemoveLast();
        }
    }

    private void FixedUpdate()
    {
        Command verticalCommand = null;
        Command horizontalCommand = null;

        if (Input.GetKey(KeyCode.W) && OnKeyW != null)
            verticalCommand = OnKeyW(new Vector2(0f, Input.GetAxis("Vertical")));
        else if (Input.GetKey(KeyCode.S) && OnKeyS != null)
            verticalCommand  = OnKeyS(new Vector2(0f, Input.GetAxis("Vertical")));

        if (Input.GetKey(KeyCode.A) && OnKeyA != null)
            horizontalCommand = OnKeyA(new Vector2(Input.GetAxis("Horizontal"), 0f));
        else if (Input.GetKey(KeyCode.D) && OnKeyD != null)
            horizontalCommand = OnKeyD(new Vector2(Input.GetAxis("Horizontal"), 0f));

        AddAndExecuteCommand(verticalCommand);
        AddAndExecuteCommand(horizontalCommand);
    }

    private void AddAndExecuteCommand(Command command)
    {
        if (command == null) return;
        AddCommand(commandsPast, command);
        command.Execute();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnMouseButtonLeftClick?.Invoke(this, EventArgs.Empty);
            //Command c = new AttackCommand();
            //AddCommand(commandsPast, c);
            //c.Execute(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnEButtonClick?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            var command = commandsFuture.First;
            if (command != null)
            {
                command.Value.Execute();
                commandsPast.AddFirst(command.Value);
                commandsFuture.RemoveFirst();
            }
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            InvokeRepeating(nameof(JumpToPast), 0f, 0.002f);
        }
    }

    void JumpToPast()
    {
        var command = commandsPast.First;
        if (command != null)
        {
            command.Value.Undo();
            commandsFuture.AddFirst(command.Value);
            commandsPast.RemoveFirst();
        }
        else
        {
            CancelInvoke(nameof(JumpToPast));
        }
    }
}

/*
 * 
 *     List<Command> commands = new List<Command>();
    int currentCommand = 0;

    void AddCommand(List<Command> list, Command c)
    {
        while (list.Count > currentCommand) list.RemoveAt(currentCommand);
        list.Add(c);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Command c = new MoveCommand(new Vector2(0f, Input.GetAxis("Vertical")));
            // PRID?TI PERRAŠYM? kad nesifill'int? list'as endlessly
            AddCommand(commands, c);
            c.Execute(gameObject);
            currentCommand++;    
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Command c = new MoveCommand(new Vector2(Input.GetAxis("Horizontal"), 0f));
            AddCommand(commands, c);
            c.Execute(gameObject);
            currentCommand++;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (currentCommand < commands.Count)
            {
                commands[currentCommand].Execute(gameObject);
                currentCommand++;
            }
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (currentCommand-1 > 0)
            {
                currentCommand--;
                commands[currentCommand].Undo(gameObject);
            }
        }
    }
*/