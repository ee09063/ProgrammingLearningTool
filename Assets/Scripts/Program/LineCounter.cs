using UnityEngine;
using System.Collections;

public class LineCounter : MonoBehaviour
{

    public int _lineCount;

    void Start()
    {
        _lineCount = 0;
    }
	
    public int getLineCount()
    {
        return _lineCount;
    }

    public void addLine()
    {
        _lineCount++;
        Debug.Log("ADDING A NEW LINE -- TOTAL " + _lineCount);
    }

    public void resetCount()
    {
        _lineCount = 0;
    }
}
