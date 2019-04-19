using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class checkTherapists : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getTherapists());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator getTherapists()
    {

        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("header-name", "header content");


        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/api/getMyPhysiotherapists"))
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
                therapistRootObject stringToken = JsonUtility.FromJson<therapistRootObject>(www.downloadHandler.text);
                Manager.GetInstance().therapistRequests.Clear();

                foreach (therapistRequestSuccess request in stringToken.data)
                {
                    Manager.GetInstance().therapistRequests.Add(request);
                }

            }
        }
    }
}
