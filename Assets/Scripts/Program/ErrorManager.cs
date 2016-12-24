using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ErrorManager
{
    private List<Error> _errors;

    public enum ErrorTypes
    {
        MISSING_TERMINATOR,
        MULTIPLE_DECLARATION,
        MISSING_DECLARATION
    }

    public List<Error> Errors
    {
        get
        {
            return _errors;
        }
    }

    public ErrorManager()
    {
        _errors = new List<Error>();
    }

    public void addError(Error error)
    {
        _errors.Add(error);
        MessageListController.AddMessageToList(error);
    }

    public void checkLineEnding(string codeLine, int lineNumber)
    {
        if (codeLine.Length == 0)
        {
            return;
        }

        Error missingSemicolon = new Error(ErrorManager.ErrorTypes.MISSING_TERMINATOR, "Missing semicolon at the end of line " + lineNumber, lineNumber);

        if (codeLine.Trim()[codeLine.Length - 1].Equals(';'))
        {
           return;
        }

        _errors.Add(missingSemicolon);
        MessageListController.AddMessageToList(missingSemicolon);
    }

    public bool hasErrors()
    {
        return _errors.Count > 0;
    }

    public static void Fix(Error error, List<string> code)
    {
        if(error.getType() == ErrorManager.ErrorTypes.MISSING_TERMINATOR)
        {
            Debug.Log("FIXING MISSING TERMINATOR");
            FixMissingTerminator(error.getLine(), code);
        }
        else if(error.getType() == ErrorManager.ErrorTypes.MISSING_DECLARATION)
        {
            Debug.Log("CANNOT FIX MISSING DECLARATION");
        }
        else if(error.getType() == ErrorManager.ErrorTypes.MULTIPLE_DECLARATION)
        {
            Debug.Log("CANNOT FIX MULTIPLE DECLARATION");
        }
    }

    private static void FixMissingTerminator(int line, List<string> code)
    {

    }
}
