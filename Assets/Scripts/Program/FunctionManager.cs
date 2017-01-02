using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;

#region Aliases
using MoveDirection = MoveCommand.Direction;

#endregion

public class FunctionManager
{
    private List<string> _declaredFunctions;
    private List<Function> _functions;
    private List<Command> _commands;
    private Function _currentFunction;
    private string _source;
    private List<string> _sourceLines;
    private LineCounter _lineCounter;

    private enum ReservedCommands
    {
        MOVE_FWD,
        MOVE_BWD,
        TURN_RIGHT,
        TURN_LEFT
    }

    public ErrorManager errorManager;

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

    public FunctionManager()
    {
        _commands = new List<Command>();
        _declaredFunctions = new List<string>();
        _functions = new List<Function>();
        errorManager = new ErrorManager();
        addReservedFunctions();
        _source = GameObject.FindGameObjectWithTag("CodeEditor").GetComponent<InputField>().text;
        _lineCounter = GameObject.FindGameObjectWithTag("LineCounter").GetComponent<LineCounter>();
        _sourceLines = new List<string>();

        using (StringReader sr = new StringReader(_source))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                _sourceLines.Add(line);
            }
        }
    }

    public void addNewLine()
    {
        _lineCounter.addLine();
    }

    /***********************************************************************************/
    /******************************      FUNCTIONS      ********************************/
    /***********************************************************************************/

    /*
    *  Adds the commands of a function to the master function 
    */
    public void addFunctionToMaster(string identifier)
    {
        int currentLine = _lineCounter.getLineCount();
        Debug.Log("ADDING FUNCTION " + identifier + " TO MASTER ON LINE " + currentLine); 

        if (identifier == null)
        {
            return;
        }
		
        if (!functionAlreadyDeclared(identifier.Trim()))
        {
            Error err = new Error("MISSING_DECLARATION", "Function " + identifier + " was not previously declared in line " + currentLine, currentLine);
            errorManager.addError(err);
            return;
        }
            
        errorManager.checkLineEnding(_sourceLines[currentLine], currentLine);

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
        int currentLine = _lineCounter.getLineCount();
        Debug.Log("DECLARING FUNCTION " + identifier + " ON LINE" + currentLine);

        if (identifier == null)
        {
            return;
        }

        if (functionAlreadyDeclared(identifier.Trim()))
        {
            Error err = new Error("MULTIPLE_DECLARATION", "Function " + identifier + " has already been declared in line " + currentLine, currentLine);
            errorManager.addError(err);
            return;
        }

        _declaredFunctions.Add(identifier.Trim());
        _currentFunction = new Function("void", identifier.Trim());
        _functions.Add(_currentFunction);
    }
        
    /*
     * Adds the commands of a function to the current function
     */
    public void addFunctionToCurrentFunction(string identifier)
    {
        int currentLine = _lineCounter.getLineCount();
        Debug.Log("ADDING FUNCTION " + identifier + " TO CURRENT FUNCTION ON LINE " + currentLine);

        if (!functionAlreadyDeclared(identifier.Trim()))
        {
            Error err = new Error("MULTIPLE_DECLARATION", "Function " + identifier + " was not previously declared in line " + currentLine, currentLine);
            errorManager.addError(err);
            return;
        }

        errorManager.checkLineEnding(_sourceLines[currentLine], currentLine);

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
    public void addForCycle(string varDec, string varInit, string varUse, string varTotal, string varInc, string valIncSymb)
    {
        int currentLine = _lineCounter.getLineCount();

        Debug.Log("Adding For Cycle");
        int varInitialValue = int.Parse(varInit);
        int varLastValue = int.Parse(varTotal);

        if (!varDec.Equals(varUse) || !varDec.Equals(varInc) || !varUse.Equals(varInc))
        {
            Error err = new Error("FOR_DIF_NAMES", "Variables have different names in line " + currentLine, currentLine);
            errorManager.addError(err);
            return;
        }

        if((varLastValue > varInitialValue && valIncSymb.Equals("--")) || (varLastValue < varInitialValue && valIncSymb.Equals("++")))
        {
            Error err = new Error("FOR_INF_CYCLE", "For will have infinite cycle in line " + currentLine, currentLine);
            errorManager.addError(err);
            return;
        }
            
        int cycles = 0;

        if(valIncSymb.Equals("++"))
        {
            cycles = varLastValue - varInitialValue;
        }
        else if(valIncSymb.Equals("--"))
        {
            cycles = Mathf.Abs(varLastValue - varInitialValue);
        }

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
