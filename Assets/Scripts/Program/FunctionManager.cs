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
 
    private enum ReservedCommands
    {
        MOVE_FWD,
        MOVE_BWD,
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
        addReservedFunctions();
    }

    public void addFunctionUse(string identifier, string args) //use a predefined or previously declared function
    {
        if (identifier == null)
        {
            return;
        }
		
        if (!functionAlreadyDeclared(identifier.Trim()))
        {
            ErrorManager.addError("Function " + identifier + "was not previously declared");
            return;
        }

        Debug.Log("USING FUNCTION " + identifier);

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

        if (functionAlreadyDeclared(identifier.Trim()))
        {
            ErrorManager.addError("Function " + identifier + " has already been declared");
            return;
        }

        Debug.Log("ADDING NEW DECLARED FUNCTION " + identifier);

        _declaredFunctions.Add(identifier.Trim());
        _currentFunction = new Function(type.Trim(), identifier.Trim());
        _functions.Add(_currentFunction);
    }
        
    public void addFunctionToCurrent(string identifier, string args)
    {
        Debug.Log("Adding " + identifier + " to current");
        List<Command> cmds = getFunctionCommands(identifier.Trim());

        foreach (Command cmd in cmds)
        {
            _functions[_functions.Count - 1].addCommand(cmd);
        }
    }

    public void addForCycle(string varDec, string varInit, string varUse, string varTotal, string varInc)
    {
        Debug.Log("Adding For Cycle");
        int varInitialValue = int.Parse(varInit);
        int varLastValue = int.Parse(varTotal);

        //check if the name of the variables matches
        if (!varDec.Equals(varUse) || !varDec.Equals(varInc) || !varUse.Equals(varInc))
        {
            Debug.Log("Variables have different names");
        }

        int cycles = varLastValue - varInitialValue;

        ForCycle forCycle = new ForCycle(cycles);

        _functions.Add(forCycle);
    }

    public void addForCycleCommands()
    {
        List<Command> forCommands = _functions[_functions.Count - 1].getCommands();

        if (forCommands == null)
        {
            Debug.LogError("For Cycle commands list is null");
            return;
        }

        foreach (Command cmd in forCommands)
        {
            _commands.Add(cmd);
        }
    }

    private void addMoveCommand(string args)
    {
        if (!MoveCommand.validateArgs(args))
        {
            ErrorManager.addError(MoveCommand.getArgsError());
            return;
        }

        string direction = args; 
        string fwdString = Enum.GetName(typeof(MoveDirection), MoveDirection.FWD);
        string identifier = direction.ToUpper().Equals(fwdString) ? "move_forward" : "move_backwards";

        List<Command> functionCommands = getFunctionCommands(identifier);
        foreach (Command cmd in functionCommands)
        {
            _commands.Add(cmd);
        }
    }

    private void addRotateCommand(float angle)
    {
        string identifier = angle == 90f ? "turn_right" : "turn_left";

        List<Command> functionCommands = getFunctionCommands(identifier);
        foreach (Command cmd in functionCommands)
        {
            _commands.Add(cmd);
        }
    }

    public void checkForErrors()
    {
        
    }

    private void addReservedFunctions()
    {            
        Function moveForward = new Function("void", "move_fwd");
        Function moveBackwards = new Function("void", "move_bwd");
        Function turnLeft = new Function("void", "turn_left");
        Function turnRight = new Function("void", "turn_right");
       
        moveForward.addCommand(new MoveCommand(MoveDirection.FWD));
        moveBackwards.addCommand(new MoveCommand(MoveDirection.BWD));
        turnLeft.addCommand(new RotateCommand(-90f));
        turnRight.addCommand(new RotateCommand(90f));
       
        _functions.Add(moveForward);
        _functions.Add(moveBackwards);
        _functions.Add(turnLeft);
        _functions.Add(turnRight);
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

    private bool functionAlreadyDeclared(string identifier)
    {
        if (identifier.Equals("for_cycle"))
        {
            return false;
        }

        foreach (Function fun in _functions)
        {
            if (identifier.Equals(fun.getIdentifier()))
            {
                return true;
            }
        }

        return false;
    }
}
