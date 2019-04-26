using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class activityInfo : MonoBehaviour
{
    [HideInInspector]
    public string activityTitle;
    [HideInInspector]
    public int listPositionActivity;
    [HideInInspector]
    public int listPositionData;

    [SerializeField]
    private GameObject titleText;

    public void setProcessTexts()
    {
        titleText.GetComponent<TextMeshProUGUI>().text = activityTitle;
        Debug.Log(listPositionActivity + "<-- activity, data --->" + listPositionData);
    }
}
