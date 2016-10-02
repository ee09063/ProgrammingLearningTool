using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SouceCodeEditor : MonoBehaviour {

	public Text sourceCode;
	public RuntimeScriptable rSObj;

	public void OnCompileAndRun()
	{
		if (rSObj != null)
		{
			rSObj.CompileAndRun (sourceCode.text);
		}
	}
}
