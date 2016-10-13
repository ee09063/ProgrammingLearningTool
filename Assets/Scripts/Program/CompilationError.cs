using UnityEngine;
using System.Collections;

public class CompilationError {
	private string _message;
	private int _line;
	private int _position;

	public CompilationError(int line, int position, string message){
		_message = message;
		_line = line;
		_position = position;
	}

	public string getMessage(){
		return _message;
	}
}
