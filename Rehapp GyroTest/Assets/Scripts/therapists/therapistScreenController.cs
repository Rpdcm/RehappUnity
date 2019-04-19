using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class therapistScreenController : MonoBehaviour
{
    [SerializeField]
    private GameObject therapistName;
    [SerializeField]
    private GameObject therapistEmail;


    // Start is called before the first frame update
    void Start()
    {
        therapistName.GetComponent<TextMeshProUGUI>().text = Manager.GetInstance().temporalTherapist.name;
        therapistEmail.GetComponent<TextMeshProUGUI>().text = Manager.GetInstance().temporalTherapist.email;
    }
  
}
