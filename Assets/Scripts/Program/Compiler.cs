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

	private List<Command> Commands {
		get {
			return _commands;
		}
	}

	private enum ReservedCommands
	{
		MOVE,
		ROTATE
	}

	public Compiler ()
	{
		_commands = new List<Command> ();
	}

	public static Program Compile (string source)
	{
		AntlrInputStream antlrStream = new AntlrInputStream (source);
		JLELexer lexer = new JLELexer (antlrStream);
		CommonTokenStream tokenStream = new CommonTokenStream (lexer);
		JLEParser parser = new JLEParser (tokenStream);

		parser.prog ();

		Compiler compiler = parser.compiler;
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
		} else if (identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.ROTATE))) {
			addRotateCommand (args);
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
		MoveDirection dir = MoveDirection.MOV_BWD;
		string fwdString = Enum.GetName (typeof(MoveDirection), MoveDirection.MOV_FWD);

		if (direction.ToUpper ().Equals (fwdString)) {
			dir = MoveDirection.MOV_FWD;
		}
		Debug.Log ("ADDING A MOVE COMMAND");
		MoveCommand moveCommand = new MoveCommand (dir);
		_commands.Add (moveCommand);
	}

	private void addRotateCommand (string args)
	{
		if (!RotateCommand.validateArgs (args)) {
			//TODO
			Debug.Log("INVALID ARGUMENTS IN ROTATE FUNCTION");
			return;
		}
		string angle = args;
		float ang = float.Parse (angle);
		RotateCommand rotateCommand = new RotateCommand (ang);
		_commands.Add (rotateCommand);
	}

	private void launchUnrecognizedFunctionException()
	{
		string warning = "This is a warning";
	}
}