using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class noItemControl : MonoBehaviour
{
    public bool activityScreen = false;
    public bool notificationScreen = false;
    public bool processScreen = false;
    public bool therapistScreen = false;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (activityScreen)
        {
            text.text = "NO TIENE NINGUNA ACTIVIDAD DISPONIBLE";
            if (Manager.GetInstance().activitiesRequests.Count != 0)
            {
                gameObject.SetActive(false);
                
            }
        }

        if (notificationScreen)
        {
            text.text = "NO TIENE NOTIFICACIONES";
            if (Manager.GetInstance().friendRequests.Count != 0)
            {
                gameObject.SetActive(false);
                
            }
        }

        if (processScreen)
        {
            text.text = "NO TIENE NINGUN PROCESO ASIGNADO";
            if (Manager.GetInstance().processRequests.Count != 0)
            {
                gameObject.SetActive(false);
                
            }
        }

        if (therapistScreen)
        {
            text.text = "NO TIENE NINGUN TERAPEUTA ASIGNADO";
            if (Manager.GetInstance().therapistRequests.Count != 0)
            {
                gameObject.SetActive(false);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
