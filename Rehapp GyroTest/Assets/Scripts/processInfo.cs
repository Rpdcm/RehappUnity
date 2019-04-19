using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class processInfo : MonoBehaviour
{
    [HideInInspector]
    public string processTitle;
    [HideInInspector]
    public int listPosition;

    [SerializeField]
    private GameObject titleText;

    public void setProcessTexts()
    {
        titleText.GetComponent<TextMeshProUGUI>().text = processTitle;
    }
}
