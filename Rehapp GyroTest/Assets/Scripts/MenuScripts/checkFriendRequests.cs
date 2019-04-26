using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;


public class checkFriendRequests : MonoBehaviour
{
    [SerializeField]
    private GameObject notificationBall;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd"));
        StartCoroutine(getFriendRequests());
    }

    private void Update()
    {
        if (Manager.GetInstance().HasFriendRequests == true)
        {
            notificationBall.SetActive(true);
        }
        else
        {
            notificationBall.SetActive(false);
        }
    }

    IEnumerator getFriendRequests()
    {

        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("header-name", "header content");


        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/api/relationship/getRelationshipRequest"))
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
                friendRootObject stringToken = JsonUtility.FromJson<friendRootObject>(www.downloadHandler.text);
                if (stringToken.data.Length == 0)
                {
                    Manager.GetInstance().HasFriendRequests = false;
                }
                else if(stringToken.data.Length > 0)
                {
                    Manager.GetInstance().HasFriendRequests = true;
                    Manager.GetInstance().friendRequests.Clear();

                    foreach (friendRequestSuccess request in stringToken.data)
                    {
                        Manager.GetInstance().friendRequests.Add(request);
                    }

                    
                }

   

            }
        }
    }



}
