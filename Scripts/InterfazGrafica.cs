using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazGrafica : MonoBehaviour
{
    [SerializeField]
    private float messageTime;

    [SerializeField]
    private GameObject messageGameObject;

    [SerializeField]
    private GameObject messageTextGameObject;

    private Text messageText;

    void Start()
    {
        messageText = messageTextGameObject.GetComponent<Text>();
        messageGameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        clearMessage();
    }

    public void showMessage(string message)
    {
        messageText.text = message;
        messageGameObject.SetActive(true);
    }

    public void clearMessage()
    {
        messageGameObject.SetActive(false);
    }
}
