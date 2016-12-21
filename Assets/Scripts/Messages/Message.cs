using UnityEngine;
using System.Collections;

public class Message
{
    private string _content;
    private string _type;

    public Message(string type, string content)
    {
        _content = content;
        _type = type;
    }

    public string getContent()
    {
        return _content;
    }

    public string getType()
    {
        return _type;
    }
}
