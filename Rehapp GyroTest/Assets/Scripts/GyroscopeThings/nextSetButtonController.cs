using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSetButtonController : MonoBehaviour
{

    public ObjectGyroMovement objectGyro;
    
    public void nextSet()
    {
        objectGyro.startNextSet();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
