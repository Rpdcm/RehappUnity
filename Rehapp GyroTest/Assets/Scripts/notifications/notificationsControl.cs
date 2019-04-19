using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notificationsControl : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject prefabNotification;
    private GameObject notification;
    private int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (friendRequestSuccess request in Manager.GetInstance().friendRequests)
        {
            notification = Instantiate(prefabNotification, panel.transform);
            notification.GetComponent<notificationInfo>().notificationTitle = "Solicitud de amistad";
            notification.GetComponent<notificationInfo>().notificationFriendName = request.user.name;
            notification.GetComponent<notificationInfo>().notificationDescription = "Has recibido una solicitud de amistad de " + request.user.name;
            notification.GetComponent<notificationInfo>().listPosition = cont;
            notification.GetComponent<notificationInfo>().setNotificationTexts();
            cont++;
        }
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
