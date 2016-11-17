using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Function
{
    private string _identifier;
    private string _type;
    private List<Command> _commands;

    public Function (string type, string identifier)
    {
        _type = type;
        _identifier = identifier;
        _commands = new List<Command>();
    }

    public string getIdentifier()
    {
        return _identifier;
    }

    public List<Command> getCommands()
    {
        return _commands;
    }

    public void addCommand(Command command)
    {
        _commands.Add(command);
    }
}
