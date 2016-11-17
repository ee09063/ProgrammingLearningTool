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
        _functions = new List<Function>();
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

        Debug.Log("USING FUNCTION " + identifier);
        _calledFunctions.Add(identifier.Trim());

        List<Command> functionCommands = getFunctionCommands(identifier);

        if (functionCommands != null)
        {
            foreach (Command cmd in getFunctionCommands(identifier))
            {
                _commands.Add(cmd);
            }
        }
    }

    public void addDeclaredFunction(string type, string identifier) // add a new function
    {
        if (identifier == null || type == null)
        {
            return;
        }

        if (_declaredFunctions.Contains(identifier.Trim()))
        {
            ErrorManager.addError("Function " + identifier + " has already been declared");
            return;
        }

        Debug.Log("ADDING NEW DECLARED FUNCTION " + identifier);
        _declaredFunctions.Add(identifier.Trim());
        _currentFunction = new Function(type.Trim(), identifier.Trim());
        _functions.Add(_currentFunction);
    }

    public void addCommand(string identifier, string args, bool insideFunction)
    {
        Debug.Log("Adding a new command");
        if (Enum.IsDefined(typeof(ReservedCommands), identifier.ToUpper())) //add a reserved command
        {
            addReservedFunction(identifier, args, insideFunction);
        }
    }

    private void addReservedFunction(string identifier, string args, bool insideFunction)
    {
        if (identifier.ToUpper().Equals(Enum.GetName(typeof(ReservedCommands), ReservedCommands.MOVE)))
        {
            addMoveCommand(args, insideFunction);
        }
        else if (identifier.ToUpper().Equals(Enum.GetName(typeof(ReservedCommands), ReservedCommands.TURN_LEFT)))
        {
            addRotateCommand(-90f, insideFunction);
        }
        else if (identifier.ToUpper().Equals(Enum.GetName(typeof(ReservedCommands), ReservedCommands.TURN_RIGHT)))
        {
            addRotateCommand(90f, insideFunction);
        }
    }
        
    private void addMoveCommand(string args, bool insideFunction)
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
        if (!insideFunction)
        {
            _commands.Add(moveCommand);
        }
        else
        {
            _currentFunction.addCommand(moveCommand);
        }
    }

    private void addRotateCommand(float angle, bool insideFunction)
    {
        RotateCommand rotateCommand = new RotateCommand(angle);
        if (!insideFunction)
        {
            _commands.Add(rotateCommand);
        }
        else
        {
            _currentFunction.addCommand(rotateCommand);
        }
    }

    public void checkForErrors()
    {
        
    }

    private void addReservedCommands()
    {
        foreach (ReservedCommands command in Enum.GetValues(typeof(ReservedCommands)))
        {
            _declaredFunctions.Add(command.ToString().ToLower());
            /*Function cmd = new Function("void", command.ToString().ToLower());
            if (cmd.Equals("move"))
            {
                cmd.addCommand(newRora)
            }*/
        }
    }

    public void oneMoreLine()
    {
        Debug.Log("ADDING ONE MORE LINE");
        lineNumber++;
    }

    private List<Command> getFunctionCommands(string identifier)
    {
        foreach(Function function in _functions)
        {
            if (function.getIdentifier().Equals(identifier))
            {
                return function.getCommands();
            }
        }

        return null;
    }
}
