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
		JSONLexer lexer = new JSONLexer (antlrStream);
		CommonTokenStream tokenStream = new CommonTokenStream (lexer);
		JSONParser parser = new JSONParser (tokenStream);

		parser.prog ();
		Compiler compiler = parser.compiler;

		if (compiler.FunctionManager.ErrorManager.hasErrors()) {
			Debug.Log ("ERRORS FOUND!");
			compiler.FunctionManager.ErrorManager.printAllErrors ();
			return null;
		}

        Debug.Log("[FUNCTION MANAGER] Number of Lines: " + compiler.FunctionManager.lineNumber);
			
		Program program = new Program (compiler.FunctionManager.Commands);

		return program;
	}
}