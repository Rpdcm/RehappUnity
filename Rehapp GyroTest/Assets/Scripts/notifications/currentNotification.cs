using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currentNotification : MonoBehaviour
{
    [SerializeField]
    private GameObject textHeader;
    [SerializeField]
    private GameObject description;

    // Start is called before the first frame update
    void Start()
    {
        textHeader.GetComponent<TextMeshProUGUI>().text = Manager.GetInstance().notificationTitle;
        description.GetComponent<TextMeshProUGUI>().text = "El fisioterapeuta "+ Manager.GetInstance().notificationName + " quiere añadirte como su paciente";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
