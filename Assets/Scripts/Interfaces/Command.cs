using UnityEngine;
using System.Collections;

public interface Command
{
	IEnumerator Execute (GameObject gameObj);
}
