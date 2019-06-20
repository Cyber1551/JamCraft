using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Body;
    public Button okButton;

    public GameObject modelPanelObject;

    private static Notification notification;
    public static Notification Instance()
    {
        if (notification == null)
        {
            notification = GameObject.FindObjectOfType(typeof(Notification)) as Notification;
            if (notification == null)
            {
                Debug.LogError("There needs to be one active Notification Script on a gameobject in your scene");
            }
        }
        return notification;
    }

    public void Choice(string title, string body, UnityAction finishEvent)
    {
        modelPanelObject.SetActive(true);
        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(ClosePanel);
        if (finishEvent != null)
        {
           
            okButton.onClick.AddListener(finishEvent);
        }
        
        Debug.Log(okButton.onClick);
        this.Title.text = title;
        this.Body.text = body;
    }
    public void ClosePanel()
    {
        modelPanelObject.SetActive(false);
    }
}
