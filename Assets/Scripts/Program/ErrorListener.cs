using UnityEngine;
using System.Collections;
using Antlr4.Runtime;

partial class ParserErrorListener : IAntlrErrorListener<IToken>
{
	public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
	{
		Debug.Log("Error in parser at LINE/COL " + ":" + e.OffendingToken.Line + " " + e.OffendingToken.Column + " MSG: " + e.Message);
	}
}

/*
public class X1Parser : BaseErrorListener
{
	public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
	{
		Debug.Log ("MESSAGE: " + msg);
	}
}
*/