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
    private string _originalLine;

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
    }

    public void OnHover()
    {
        if(_message.getType().Equals("Error"))
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

            Error err = _message as Error;
            _line = err.getLine();
            _originalLine = _code[_line];
        }

        _codeMask.transform.SetParent(_inputField.transform);

        Text mask = _codeMask.GetComponentInChildren<Text>();
        mask.text = "";
        _code[_line] = "<color=#ff0000ff>" + _originalLine + "</color>";

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
        Error error = _message as Error;

        if (error.isFixed())
        {
            return;
        }

        Debug.Log(error.getType());

        if(error.getType().Equals("MISSING_TERMINATOR"))
        {
            Debug.Log("FIXING MISSING TERMINATOR");
            _originalLine += ";";
            _code[_line] = _originalLine;
            _inputField.GetComponent<InputField>().text = "";
            foreach (string str in _code)
            {
                _inputField.GetComponent<InputField>().text += str + "\n";
            }
            error.setFixed(true);
            OnHover();
        }
        else if(error.getType().Equals("MISSING_DECLARATION"))
        {
            Debug.Log("CANNOT FIX MISSING DECLARATION");
        }
    }
}
