using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SouceCodeEditor : MonoBehaviour {

	public Text sourceCode;
	public RuntimeScriptable rSObj;

	public void OnCompileAndRun()
	{
        MessageListController.DeleteMessages();

        if (rSObj == null)
		{
            return;
		}

        rSObj.CompileAndRun (sourceCode.text);
	}
}
