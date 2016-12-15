using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForCycle : Function
{
    private int _cycles;

    public ForCycle(int cycles) : base("for", "for_cycle")
    {
        _cycles = cycles;
    }
        
    public override List<Command> getCommands()
    {
        List<Command> forList = new List<Command>();

        for (int i = 0; i < _cycles; i++)
        {
            foreach (Command cmd in _commands)
            {
                forList.Add(cmd);
            }
        }

        return forList;
    }
}
