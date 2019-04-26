using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class completeActivity : MonoBehaviour
{
    public void completeTheActivity()
    {
        StartCoroutine(completeCurrentActivity());
    }

    IEnumerator completeCurrentActivity()
    {  
        WWWForm form = new WWWForm();
        form.AddField("user_id", Manager.GetInstance().temporalActivity.user_id);
        form.AddField("id", Manager.GetInstance().temporalActivity.id);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/completeActivity", form))
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
                
            }
        }
    }
}
