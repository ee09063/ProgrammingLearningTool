using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

#region Aliases
using MoveDirection = MoveCommand.Direction;

#endregion

public class FunctionManager
{
    private List<string> _calledFunctions;
    private List<string> _declaredFunctions;
    private List<Function> _functions;
    private List<Command> _commands;
    private ErrorManager _errorManager;
    private Function _currentFunction;

    public int lineNumber;

    private enum ReservedCommands
    {
        MOVE,
        TURN_RIGHT,
        TURN_LEFT
    }

    public List<Command> Commands
    {
        get
        {
            return _commands;
        }
    }

    public List<string> CalledFunctions
    {
        get
        {
            return _calledFunctions;
        }
    }

    public List<string> DeclaredFunctions
    {
        get
        {
            return _declaredFunctions;
        }
    }

    public ErrorManager ErrorManager
    {
        get
        {
            return _errorManager;
        }
    }

    public FunctionManager()
    {
        _commands = new List<Command>();
        _calledFunctions = new List<string>();
        _declaredFunctions = new List<string>();
        _errorManager = new ErrorManager();
        addReservedCommands();
        lineNumber = 0;
    }

    public void addFunctionUse(string identifier) //use a predefined or previously declared function
    {
        if (identifier == null)
        {
            return;
        }
        if (!_declaredFunctions.Contains(identifier.Trim()))
        {
            ErrorManager.addError("Function " + identifier + "was not previously declared");
            return;
        }
        _calledFunctions.Add(identifier.Trim());
    }

    public void addDeclaredFunction(string identifier)
    {
        if (identifier == null)
        {
            return;
        }
        if (_declaredFunctions.Contains(identifier.Trim()))
        {
            ErrorManager.addError("Function " + identifier + " has already been declared");
            return;
        }
        _declaredFunctions.Add(identifier.Trim());
    }

    public void addCommand(string identifier, string args)
    {
        if (Enum.IsDefined(typeof(ReservedCommands), identifier.ToUpper())) //add a reserved command
        {
            addReservedFunction(identifier, args);
        }
    }

    private void addReservedFunction(string identifier, string args)
    {
        if (identifier.ToUpper().Equals(Enum.GetName(typeof(ReservedCommands), ReservedCommands.MOVE)))
        {
            addMoveCommand(args);
        }
        else if (identifier.ToUpper().Equals(Enum.GetName(typeof(ReservedCommands), ReservedCommands.TURN_LEFT)))
        {
            addRotateCommand(-90f);
        }
        else if (identifier.ToUpper().Equals(Enum.GetName(typeof(ReservedCommands), ReservedCommands.TURN_RIGHT)))
        {
            addRotateCommand(90f);
        }
    }

    public void addNewFunction(string type, string identifier, string args)
    {
        Debug.Log("ADDING NEW FUNCTION: " + type + " " + identifier + " " + args); 
        _currentFunction = new Function(type, identifier);
    }

    private void addMoveCommand(string args)
    {
        if (!MoveCommand.validateArgs(args))
        {
            ErrorManager.addError(MoveCommand.getArgsError());
            return;
        }
        string direction = args; 
        MoveDirection dir = MoveDirection.BWD;
        string fwdString = Enum.GetName(typeof(MoveDirection), MoveDirection.FWD);
        if (direction.ToUpper().Equals(fwdString))
        {
            dir = MoveDirection.FWD;
        }
        MoveCommand moveCommand = new MoveCommand(dir);
        _commands.Add(moveCommand);
    }

    private void addRotateCommand(float angle)
    {
        RotateCommand rotateCommand = new RotateCommand(angle);
        _commands.Add(rotateCommand);
    }

    public void checkForErrors()
    {
        
    }

    private void addReservedCommands()
    {
        foreach (ReservedCommands command in Enum.GetValues(typeof(ReservedCommands)))
        {
            _declaredFunctions.Add(command.ToString().ToLower());
        }
    }

    public void oneMoreLine()
    {
        Debug.Log("ADDING ONE MORE LINE");
        lineNumber++;
    }
}
