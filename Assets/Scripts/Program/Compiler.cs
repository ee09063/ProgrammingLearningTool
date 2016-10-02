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

	public void addGenericCommand (string identifier, string arg)
	{
		Debug.Log ("asdasdasd");
		Debug.Log (arg);
		if (Enum.IsDefined (typeof(ReservedCommands), identifier.ToUpper ())) {
			addReservedCommand (identifier, arg);
		}
	}

	private void addReservedCommand (string identifier, string arg)
	{
		if (identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.MOVE))) {
			addMoveCommand (arg);
		} else if (identifier.ToUpper ().Equals (Enum.GetName (typeof(ReservedCommands), ReservedCommands.ROTATE))) {
			addRotateCommand (arg);
		}
	}

	private void addMoveCommand (string direction)
	{
		MoveDirection dir = MoveDirection.MOV_BWD;
		string fwdString = Enum.GetName (typeof(MoveDirection), MoveDirection.MOV_FWD);

		if (direction.ToUpper ().Equals (fwdString)) {
			dir = MoveDirection.MOV_FWD;
		}

		MoveCommand moveCommand = new MoveCommand (dir);
		_commands.Add (moveCommand);
	}

	private void addRotateCommand (string angle)
	{
		float ang = float.Parse (angle);
		RotateCommand rotateCommand = new RotateCommand (ang);
		_commands.Add (rotateCommand);
	}
}