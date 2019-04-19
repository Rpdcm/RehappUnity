using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;
    public GameObject noGyro;
    [HideInInspector]
    public bool hasGyro = false;

	// Use this for initialization
	void Start () {
        noGyro.SetActive(false);
        gyroEnabled = EnableGyro();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            hasGyro = true;
            return true;
        }
        else
        {
            noGyro.SetActive(true);
            return false;
        }

    }
}
