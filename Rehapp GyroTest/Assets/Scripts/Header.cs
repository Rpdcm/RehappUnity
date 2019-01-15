using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Header : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI headerText;

	// Use this for initialization
	void Start () {
        headerText.text = "Bienvenido, " + Manager.GetInstance().Username;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
