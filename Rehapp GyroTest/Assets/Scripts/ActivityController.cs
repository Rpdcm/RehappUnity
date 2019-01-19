using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivityController : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI activityName;
    [SerializeField]
    private TextMeshProUGUI activityDescription;

	// Use this for initialization
	void Start () {
        activityName.text = Manager.GetInstance().ActivityName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
