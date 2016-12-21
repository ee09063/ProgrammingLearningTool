using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static float EXECUTION_DELAY = 0.5f;
    public static bool currentCommandOver;

    private List<Command> _commands;
    private int _commandCount;

    public Program(List<Command> commands)
    {
        _commands = commands;
        _commandCount = 0;
        currentCommandOver = false;
    }

    public IEnumerator Run(GameObject gameObj)
    {
        MessageListController.DeleteMessages();

        while (_commandCount < _commands.Count)
        {
            yield return new WaitForSeconds(EXECUTION_DELAY);

            currentCommandOver = false;

            Command nextCommand = _commands[_commandCount++];
            yield return nextCommand.Execute(gameObj);
            while (!currentCommandOver)
            {
                yield return null;
            }
            //currentCommandOver = false;
        }
    }

    public void Reset()
    {
        _commandCount = 0;
    }
}
