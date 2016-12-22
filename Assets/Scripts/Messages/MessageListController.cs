using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MessageListController : MonoBehaviour
{
    private static List<GameObject> _messages;
    private static GameObject _container;

    public static void AddMessageToList(Message message)
    {
        GameObject msg = GameObject.Instantiate(Resources.Load("Message", typeof (GameObject))) as GameObject;

        Text messageText = msg.GetComponentInChildren<Text>();
        messageText.text = message.getContent();
        messageText.color = message.getColor();

        msg.transform.SetParent(_container.transform);

        _messages.Add(msg);
    }

    public static void DeleteMessages()
    {
        foreach (GameObject msg in _messages)
        {
            GameObject.Destroy(msg);
        }
        _messages.Clear();
    }

    void Awake()
    {
        _messages = new List<GameObject>();
        _container = GameObject.FindGameObjectWithTag("MessageContainer");
    }
}
