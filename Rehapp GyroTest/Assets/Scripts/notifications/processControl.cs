using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class processControl : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject prefabProcess;
    private GameObject process;
    private int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (processRequestSuccess request in Manager.GetInstance().processRequests)
        {
            process = Instantiate(prefabProcess, panel.transform);
            process.GetComponent<processInfo>().processTitle = request.name;
            process.GetComponent<processInfo>().listPosition = cont;
            process.GetComponent<processInfo>().setProcessTexts();
            cont++;
        }
        cont = 0;
    }
    
}
