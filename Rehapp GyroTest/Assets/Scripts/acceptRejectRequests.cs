using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class acceptRejectRequests : MonoBehaviour
{

    public string answerOption;
    private string userID;
    private string relationshipID;

    // Start is called before the first frame update
    void Start()
    {
        userID = Manager.GetInstance().friendRequests[Manager.GetInstance().notificationListNumber].user_id;
        relationshipID = Manager.GetInstance().friendRequests[Manager.GetInstance().notificationListNumber].id;
        Debug.Log(userID + "   " + relationshipID + "    " + answerOption);
    }
    

    public void acceptReject()
    {
        StartCoroutine(RespondRequest());
    }

    IEnumerator RespondRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", userID);
        form.AddField("relationshipRequest_id", relationshipID);
        form.AddField("answer", answerOption);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/relationship/acceptRejectRelationshipRequest", form))
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
                Debug.Log("FriendRequest Done!");
                SceneManager.LoadScene("MainScreen");
            }
        }
    }

}
