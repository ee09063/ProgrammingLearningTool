using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MessageItemController : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField;
    private GameObject _codeMask;
    private GameObject _codePanel;

    private Message _message;
    private List<string> _code;
    private int _line;

    void Awake()
    {
        _inputField = GameObject.FindGameObjectWithTag("CodeEditor").GetComponent<InputField>();
        _codeMask = GameObject.FindGameObjectWithTag("CodeMask");
        _codePanel = GameObject.FindGameObjectWithTag("CodePanel");
        _codeMask.transform.SetParent(_codePanel.transform);
    }

    public void setMessage(Message message)
    {
        _message = message;
        Text messageText = GetComponentInChildren<Text>();
        messageText.text = message.getContent();
        messageText.color = message.getColor();

        if(message.getType().Equals("Error"))
        {
            _code = new List<string>();
            string fullCode = _inputField.GetComponentInChildren<Text>().text;

            using (StringReader sr = new StringReader(fullCode))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _code.Add(line);
                }
            }

            Error err = message as Error;
            _line = err.getLine();
            _code[_line] = "<color=#ff0000ff>" + _code[_line] + "</color>";
        }
    }

    public void OnHover()
    {
        _codeMask.transform.SetParent(_inputField.transform);
        Text mask = _codeMask.GetComponentInChildren<Text>();
        mask.text = "";
        foreach(string str in _code)
        {
            mask.text += str + "\n";
        }
    }

    public void OnHoverLost()
    {
        _codeMask.transform.SetParent(_codePanel.transform);
        _codeMask.transform.SetAsFirstSibling();
    }

    public void OnClick()
    {
        ErrorManager.Fix(_message as Error, _code);
        for (int i = 0; i < _code.Count; i++)
        {
            Debug.Log(i + " -- " + _code[i]);
        }
    }
}
