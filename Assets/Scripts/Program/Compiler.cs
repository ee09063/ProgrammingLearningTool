using UnityEngine;
using System.Collections;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;

public class Compiler
{
	private FunctionManager _functionManager;


	public FunctionManager FunctionManager {
		get {
			return _functionManager;
		}
	}
		
	public Compiler ()
	{
		_functionManager = new FunctionManager ();
	}

	public Program Compile (string source)
	{
		AntlrInputStream antlrStream = new AntlrInputStream (source);
		JLELexer lexer = new JLELexer (antlrStream);
		CommonTokenStream tokenStream = new CommonTokenStream (lexer);
		JLEParser parser = new JLEParser (tokenStream);

		parser.prog ();
		Compiler compiler = parser.compiler;

		if (compiler.FunctionManager.ErrorManager.hasErrors()) {
			Debug.Log ("ERRORS FOUND!");
			FunctionManager.ErrorManager.printAllErrors ();
			return null;
		} else {
			Debug.Log ("NO ERRORS FOUND");
		}
			
		Program program = new Program (compiler.FunctionManager.Commands);

		return program;
	}
}