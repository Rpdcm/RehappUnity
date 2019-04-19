using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class notificationInfo : MonoBehaviour
{

    [HideInInspector]
    public string notificationTitle;
    [HideInInspector]
    public string notificationDescription;
    [HideInInspector]
    public string notificationFriendName;
    [HideInInspector]
    public int listPosition;

    [SerializeField]
    private GameObject titleText;
    [SerializeField]
    private GameObject descriptionText;
    
    public void setNotificationTexts()
    {
        titleText.GetComponent<TextMeshProUGUI>().text = notificationTitle;
        descriptionText.GetComponent<TextMeshProUGUI>().text = notificationDescription;
    }


}
