using UnityEngine;
using System.Collections;

public class Message
{
    private string _content;
    private string _type;
    private Color _color;

    public Message(string type, string content)
    {
        _content = content;
        _type = type;
        _color = type.Equals("Error") ? Color.red : Color.black;
    }

    public string getContent()
    {
        return _content;
    }

    public string getType()
    {
        return _type;
    }

    public Color getColor()
    {
        return _color;
    }
}
