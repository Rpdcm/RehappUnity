using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class therapistControl : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject prefabTherapist;
    private GameObject therapist;
    private int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (therapistRequestSuccess request in Manager.GetInstance().therapistRequests)
        {
            therapist = Instantiate(prefabTherapist, panel.transform);
            therapist.GetComponent<therapistInfo>().therapistName = request.name;
            therapist.GetComponent<therapistInfo>().listPosition = cont;
            therapist.GetComponent<therapistInfo>().setTherapistTexts();
            cont++;
        }
        cont = 0;
    }

}
