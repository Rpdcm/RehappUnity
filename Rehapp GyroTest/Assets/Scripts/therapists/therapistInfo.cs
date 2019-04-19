using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class therapistInfo : MonoBehaviour
{
    [HideInInspector]
    public string therapistName;
    [HideInInspector]
    public int listPosition;

    [SerializeField]
    private GameObject titleText;

    public void setTherapistTexts()
    {
        titleText.GetComponent<TextMeshProUGUI>().text = therapistName;
    }
}
