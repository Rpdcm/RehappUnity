using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class checkActivities : MonoBehaviour
{
    private processInfo process;

    private void Start()
    {
        process = GetComponent<processInfo>();
    }

    public void goToActivities()
    {
        StartCoroutine(getActivities());
    }

    IEnumerator getActivities()
    {

        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("header-name", "header content");


        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/api/getRehabprocessActivities/" + Manager.GetInstance().processRequests[process.listPosition].id))
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
                Manager.GetInstance().activitiesRequests.Clear();

                activitiesRootObject stringToken = JsonUtility.FromJson<activitiesRootObject>(www.downloadHandler.text);

                foreach (activitiesRequestSuccess request in stringToken.data)
                {
                    Manager.GetInstance().activitiesRequests.Add(request);
                }
                SceneManager.LoadScene("ActivityScreen");
            }
        }
    }
}
