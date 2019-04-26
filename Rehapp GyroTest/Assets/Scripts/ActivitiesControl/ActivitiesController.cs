using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesController : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject prefabActivities;
    private GameObject activity;
    private int cont = 0;
    private int contActivity = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (activitiesRequestSuccess request in Manager.GetInstance().activitiesRequests)
        {
            foreach (activitiesList activityFromArray in request.activities)
            {
                if (activityFromArray.date == System.DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    activity = Instantiate(prefabActivities, panel.transform);
                    activity.GetComponent<activityInfo>().activityTitle = activityFromArray.name;
                    activity.GetComponent<activityInfo>().listPositionActivity = contActivity;
                    activity.GetComponent<activityInfo>().listPositionData = cont;
                    Debug.Log("activitiesRequest() "+Manager.GetInstance().activitiesRequests.Count);
                    Debug.Log("activitiesRequest().activities() " + request.activities.Length);
                    activity.GetComponent<activityInfo>().setProcessTexts();
                    
                }
                contActivity++;
            }
            cont++;
            contActivity = 0;
        }
        
        cont = 0;
    }
}
