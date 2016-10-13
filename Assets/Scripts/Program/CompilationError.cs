using UnityEngine;
using System.Collections;

public class CompilationError {
	private string _message;
	private int _line;
	private int _position;

	public CompilationError(){
		
	}

	public string getMessage(){
		return _message;
	}

	public void missingLineEnding()
	{
		_message = "MISSING LINE TERMINATOR -> ;";
	}

	public void unrecognizedFunction(string identifier)
	{
		_message = identifier + " IS NOT A RECOGNIZED FUNCTION";
	}
}
