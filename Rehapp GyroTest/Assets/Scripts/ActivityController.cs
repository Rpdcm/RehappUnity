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
        activityName.text = Manager.GetInstance().ActivityName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void completeActivity()
    {
        
    }
}
