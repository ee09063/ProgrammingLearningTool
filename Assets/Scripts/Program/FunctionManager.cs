using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

#region Aliases
using MoveDirection = MoveCommand.Direction;

#endregion

public class FunctionManager {

	private List<string> _functionNames;
	private List<string> _declaredFunctions;
	private List<Command> _commands;
	private ErrorManager _errorManager;


	private enum ReservedCommands
	{
		MOVE,
		TURN_RIGHT,
		TURN_LEFT
	}

	public List<Command> Commands {
		get {
			return _commands;
		}
	}

	public List<string> FunctionNames
	{
		get{
			return _functionNames;
		}
	}

	public List<string> DeclaredFunctions
	{
		get{
			return _declaredFunctions;
		}
	}

	public ErrorManager ErrorManager {
		get {
			return _errorManager;
		}
	}

	public FunctionManager()
	{
		_commands = new List<Command> ();
		_functionNames = new List<string> ();
		_declaredFunctions = new List<string> ();
		_errorManager = new ErrorManager ();
	}

	public void addGenericCommand (string identifier, string args)
	{
		Debug.Log ("ADDING GENERIC COMMAND: " + identifier);
		if (Enum.IsDefined (typeof(ReservedCommands), identifier.ToUpper ())) {
			addReservedCommand (identifier, args);
		}
	}

	private void addReservedCommand (string identifier, string args)
	{
		Debug.Log ("ADDING RESERVED COMMAND");
		if (identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.MOVE))) {
			addMoveCommand (args);
		} else if (identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.TURN_LEFT))) {
			addRotateCommand (-90f);
		} else if (identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.TURN_RIGHT))) {
			addRotateCommand (90f);
		}
	}

	private void addMoveCommand (string args)
	{
		if (!MoveCommand.validateArgs (args)) {
			ErrorManager.addError (MoveCommand.getArgsError ());
			return;
		}
		string direction = args; 
		MoveDirection dir = MoveDirection.BWD;
		string fwdString = Enum.GetName (typeof(MoveDirection), MoveDirection.FWD);
		if (direction.ToUpper ().Equals (fwdString)) {
			dir = MoveDirection.FWD;
		}
		MoveCommand moveCommand = new MoveCommand (dir);
		_commands.Add (moveCommand);
	}

	private void addRotateCommand (float angle)
	{
		RotateCommand rotateCommand = new RotateCommand (angle);
		_commands.Add (rotateCommand);
	}

	public void addFunctionName(string identifier){
		Debug.Log ("[FUNCTION MANAGER] Adding function name");
		if(identifier != null)
			_functionNames.Add (identifier);
	}

	public void addDeclaredFunction(string identifier){
		Debug.Log ("[FUNCTION MANAGER] Adding declared function");
		if(identifier != null)
			_declaredFunctions.Add (identifier);
	}
}
