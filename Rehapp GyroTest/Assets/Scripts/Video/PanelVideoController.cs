using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVideoController : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private bool activePanel = false;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

        if (activePanel)
        {
            
        }
    }
}
