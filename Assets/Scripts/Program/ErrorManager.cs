using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ErrorManager {

	private List<string> _errors;

	public List<string> Errors
	{
		get
		{
			return _errors;
		}
	}

	public ErrorManager()
	{
		_errors = new List<string> ();
	}
		
	public void addError(string message)
	{
		Debug.Log (message);
		_errors.Add (message);
	}

	public void checkLineEnding(string lineEnding)
	{
		Debug.Log ("[ERROR MANAGER] Checking Line Ending");
		if (lineEnding == null) {
			addError ("[ERROR MANAGER] Adding a missin Line Ending Error");
		} else {
			if (!lineEnding.Trim ().Equals (";")) {
				addError ("[ERROR MANAGER] Adding a missin Line Ending Error");
			}
		}
	}

	public bool hasErrors()
	{
		Debug.Log("[ERROR MANAGER] We have " + _errors.Count + " errors");
		return _errors.Count > 0;
	}

	public void printAllErrors(){
		foreach(string err in _errors){
			Debug.Log (err);
		}
	}
}
