using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ActivitiesPanelMenu : MonoBehaviour
{
    private int cont = -1;
    private int contTodayActivities = 0;
    private int contDoneActivities = 0;
    private int contTotalActivities  = 0;
    [SerializeField]
    private TextMeshProUGUI doneActivities;
    [SerializeField]
    private TextMeshProUGUI todayActivities;
    [SerializeField]
    private GameObject loadingPanel;
    private MoodScript mood;

    private void Start()
    {
        mood = GetComponent<checkProcess>().mood;
    }

    public void getActivitiesForMenu()
    {
        for(int i = 0; i < Manager.GetInstance().processRequests.Count; i++)
        {
            StartCoroutine(getActivities());
        }
        
    }

    private void setTexts()
    {
        doneActivities.text = contDoneActivities.ToString();
        todayActivities.text = contTodayActivities.ToString();
        manageMood();
        mood.setMood();
        
    }

    public void turnLoadingPanelOff()
    {
        loadingPanel.SetActive(false);
    }

    private void manageMood()
    {
        if (contTotalActivities == 0)
        {
            Manager.GetInstance().mood = "WELCOME";
        }
        if(contDoneActivities > 0 && contDoneActivities < contTotalActivities)
        {
            Manager.GetInstance().mood = "HAPPY";
        }
        if(contDoneActivities == contTotalActivities)
        {
            Manager.GetInstance().mood = "SUPERHAPPY";
        }
        if(contDoneActivities == 0 && contTodayActivities > 0)
        {
            Manager.GetInstance().mood = "STARTACTIVITIES";
        }
    }

    IEnumerator getActivities()
    {
        cont++;

        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("header-name", "header content");


        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/api/getRehabprocessActivities/" + Manager.GetInstance().processRequests[cont].id))
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

                //Manager.GetInstance().activitiesRequests.Clear();

                activitiesRootObject stringToken = JsonUtility.FromJson<activitiesRootObject>(www.downloadHandler.text);

                foreach (activitiesRequestSuccess request in stringToken.data)
                {
                    foreach(activitiesList activity in request.activities)
                    {
                        if(activity.date == System.DateTime.Now.ToString("yyyy-MM-dd") && activity.state == "Active")
                        {
                            contTodayActivities++;
                            contTotalActivities++;
                        }
                        else if(activity.date == System.DateTime.Now.ToString("yyyy-MM-dd") && activity.state != "Active")
                        {
                            contDoneActivities++;
                            contTotalActivities++;
                        }
                        
                    }
                }
                
                if(cont == Manager.GetInstance().processRequests.Count - 1)
                {
                    setTexts();
                }

            }
        }
    }
}
