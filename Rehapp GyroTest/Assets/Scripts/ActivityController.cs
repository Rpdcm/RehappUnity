using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivityController : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI activityName;
    [SerializeField]
    private TextMeshProUGUI activityDescription;
    [SerializeField]
    private TextMeshProUGUI t_activityCompleted;
    [SerializeField]
    private Image calification;

    


	// Use this for initialization
	void Start () {
        activityName.text = Manager.GetInstance().temporalActivity.name;
        activityDescription.text = Manager.GetInstance().temporalActivity.description;
        if (Manager.GetInstance().temporalActivity.state == "Active")
        {
            t_activityCompleted.text = "Actividad no completada";
        }
        else
        {
            t_activityCompleted.text = "Actividad realizada";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void completeActivity()
    {
        
    }
}
