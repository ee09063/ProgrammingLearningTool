using UnityEngine;
using System.Collections;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;
using System;

#region Aliases
using MoveDirection = MoveCommand.Direction;

#endregion

public class Compiler
{
	private List<Command> _commands;
	private List<CompilationError> _errors;

	private List<Command> Commands {
		get {
			return _commands;
		}
	}

	private List<CompilationError> Errors
	{
		get {
			return _errors;
		}
	}

	private enum ReservedCommands
	{
		MOVE,
		TURN_RIGHT,
		TURN_LEFT
	}

	public Compiler ()
	{
		_commands = new List<Command> ();
		_errors = new List<CompilationError> ();
	}

	public Program Compile (string source)
	{
		AntlrInputStream antlrStream = new AntlrInputStream (source);
		JLELexer lexer = new JLELexer (antlrStream);
		CommonTokenStream tokenStream = new CommonTokenStream (lexer);
		JLEParser parser = new JLEParser (tokenStream);

		parser.prog ();
		Compiler compiler = parser.compiler;

		if (compiler.Errors.Count > 0) {
			Debug.Log ("ERRORS FOUND!");
			printAllErrors ();
			return null;
		} else {
			Debug.Log ("NO ERRORS FOUND");
		}
			
		Program program = new Program (compiler.Commands);

		return program;
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
		} else if(identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.TURN_RIGHT))) {
			addRotateCommand (90f);
		}

		launchUnrecognizedFunctionException ();
	}

	private void addMoveCommand (string args)
	{
		if (!MoveCommand.validateArgs (args)) {
			//TODO
			Debug.Log(MoveCommand.getArgsError());
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

	private void launchUnrecognizedFunctionException()
	{
		string warning = "This is a warning";
	}

	public void checkLineEnding(string lineEnding)
	{
		if (lineEnding == null) {
			_errors.Add (new CompilationError (0, 0, "MISSING LINE TERMINATOR -> ;"));
		}
	}

	public void printAllErrors(){
		foreach(CompilationError err in _errors){
			Debug.Log (err.getMessage ());
		}
	}
}