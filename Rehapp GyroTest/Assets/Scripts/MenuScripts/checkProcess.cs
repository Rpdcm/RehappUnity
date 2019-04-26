using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class checkProcess : MonoBehaviour
{
    private ActivitiesPanelMenu panelActivities;
    public MoodScript mood;
    private bool processCompleted = false;
    public bool mainMenu = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getProcess());
        panelActivities = GetComponent<ActivitiesPanelMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(processCompleted && mainMenu)
        {
            panelActivities.getActivitiesForMenu();
            panelActivities.turnLoadingPanelOff();
            processCompleted = false;
        }
    }

    IEnumerator getProcess()
    {

        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("header-name", "header content");


        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/api/rehabprocess/userrehabprocess"))
        {
            www.SetRequestHeader("Authorization", Manager.GetInstance().userToken);
            www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            www.SetRequestHeader("Accept", "application/json");

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                processRootObject stringToken = JsonUtility.FromJson<processRootObject>(www.downloadHandler.text);
                Manager.GetInstance().processRequests.Clear();
           
                foreach (processRequestSuccess request in stringToken.data)
                {
                    Manager.GetInstance().processRequests.Add(request);
                    
                }

                
            }

            processCompleted = true;
        }
    }

    
}
