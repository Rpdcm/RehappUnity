using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVideoController : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject skipButton;

    private bool activePanel = false;
    
    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        playButton.SetActive(false);
        skipButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if(activePanel)
        {
            if (time > 5)
            {
                closePanel();
            }
            
        }
        
    }

    public void openClosePanel()
    {
        if (activePanel)
        {
            closePanel();
        }
        else
        {
            openPanel();
        }
        
    }

    public void closePanel()
    {
        time = 0;
        activePanel = false;
        panel.SetActive(false);
        playButton.SetActive(false);
        skipButton.SetActive(false);
    }

    public void openPanel()
    {
        time = 0;
        activePanel = true;
        playButton.SetActive(true);
        panel.SetActive(true);
        skipButton.SetActive(true);
    }

}
