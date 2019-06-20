using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotificationController : MonoBehaviour
{
    private Notification notification;
    // Start is called before the first frame update
    private void Awake()
    {
        notification = Notification.Instance();
    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyUp(KeyCode.Space))
        {
            notification.Choice("Space", "Space was pressed", new UnityAction(NextNotification));
        }
    }
    public void NextNotification()
    {
       
        notification.Choice("Next Notification", "YAY it works", null);
    }
}
