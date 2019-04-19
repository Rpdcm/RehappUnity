using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class GetData : MonoBehaviour
{

    [SerializeField]
    private GameObject incorrectText;
   

    public void getData()
    {
        StartCoroutine(getUserData());
        StartCoroutine(getActivities());
    }

    IEnumerator getUserData()
    {

        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("header-name", "header content");
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/details", form))
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
                //Debug.Log(www.downloadHandler.text);
                rootObject stringToken = JsonUtility.FromJson<rootObject>(www.downloadHandler.text);
                Manager.GetInstance().Username = stringToken.success.name;
                Manager.GetInstance().UserId = stringToken.success.id;
                Manager.GetInstance().UserAge = stringToken.success.age;
                Manager.GetInstance().UserEmail = stringToken.success.email;
                Manager.GetInstance().Email_verified_at = stringToken.success.email_verified_at;
                Manager.GetInstance().User_role_id = stringToken.success.role_id;

                if (stringToken.success.role_id != "1")
                {
                    incorrectText.SetActive(true);
                    incorrectText.GetComponent<TextMeshProUGUI>().text = "En este momento la aplicación solo está disponible para los pacientes";
                }
                else
                {
                    SceneManager.LoadScene("MainScreen");
                }
            }
        }
    }

    IEnumerator getActivities()
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
                
            }
        }
    }


    [Serializable]
    public class rootObject
    {
        public Success success;

    }

    [Serializable]
    public class Success
    {
        public string id;
        public string name;
        public string age;
        public string email;
        public string email_verified_at;
        public string role_id;
    }


}
