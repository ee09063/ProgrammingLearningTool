using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Program
{
	public static float EXECUTION_DELAY = 0.5f;

	private List<Command> _commands;
	private int _commandCount;

	public Program (List<Command> commands)
	{
		_commands = commands;
		_commandCount = 0;
	}

	public IEnumerator Run (GameObject gameObj)
	{
		while (_commandCount < _commands.Count)
		{
			yield return new WaitForSeconds (EXECUTION_DELAY);

			Command nextCommand = _commands [_commandCount++];
			yield return nextCommand.Execute (gameObj);
		}
	}

	public void Reset()
	{
		_commandCount = 0;
	}
}
