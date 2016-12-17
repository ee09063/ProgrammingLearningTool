using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

#region Aliases
using MoveDirection = MoveCommand.Direction;

#endregion

public class FunctionManager
{
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
        _declaredFunctions = new List<string>();
        _functions = new List<Function>();
        _errorManager = new ErrorManager();
        addReservedFunctions();
    }

    /***********************************************************************************/
    /******************************      FUNCTIONS      ********************************/
    /***********************************************************************************/

    /*
    *  Adds the commands of a function to the master function 
    */
    public void addFunctionToMaster(string identifier)
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

    /*
     *  Adds a new declared function 
     */
    public void addDeclaredFunction(string identifier) // add a new function
    {
        if (identifier == null)
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
        _currentFunction = new Function("void", identifier.Trim());
        _functions.Add(_currentFunction);
    }
        
    /*
     * Adds the commands of a function to the current function
     */
    public void addFunctionToCurrentFunction(string identifier)
    {
        Debug.Log("Adding " + identifier + " to current");
        List<Command> cmds = getFunctionCommands(identifier.Trim());

        foreach (Command cmd in cmds)
        {
            _functions[_functions.Count - 1].addCommand(cmd);
        }
    }

    /****************** FOR CYCLE ********************************/

    /*
     * Adds for cycle to the _for_functions List
     */
    public void addForCycle(string varDec, string varInit, string varUse, string varTotal, string varInc)
    {
        Debug.Log("Adding For Cycle");
        int varInitialValue = int.Parse(varInit);
        int varLastValue = int.Parse(varTotal);

        if (!varDec.Equals(varUse) || !varDec.Equals(varInc) || !varUse.Equals(varInc))
        {
            Debug.Log("Variables have different names");
        }

        int cycles = varLastValue - varInitialValue;

        ForCycle forCycle = new ForCycle(cycles);

        _functions.Add(forCycle);
    }

    /*
     * Adds the commands of a for cycle to the master function
     */
    public void addForCycleCommandsToMaster()
    {
        Debug.Log("Adding for cycle commands to master commands list");
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
        
    /*
     * Adds the commands of a for cycle to the current function
     */
    public void addForCycleCommandsToCurrentFunction()
    {
        Function forCycle = _functions[_functions.Count - 1];
        Function target = null;

        for (int i = 0; i < _functions.Count; i++)
        {
            Debug.Log(_functions[i].getIdentifier());
        }

        for (int i = _functions.Count - 1; i >= 0; i--)
        {
            Function fun = _functions[i];
            if (!fun.getIdentifier().Equals("for_cycle"))
            {
                target = fun;
                break;
            }
        }

        if (target == null)
        {
            Debug.LogError("Target function is null");
        }

        Debug.Log("Adding for cycle commands to function " + target.getIdentifier());

        foreach (Command cmd in forCycle.getCommands())
        {
            target.addCommand(cmd);
        }
    }

    /***********************************************************************************/
    /******************************      COMMANDS      *********************************/
    /***********************************************************************************/

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
        foreach (Function function in _functions)
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
