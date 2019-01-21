using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{

    private static Manager instance;
    private string username;
    private string activityName;
    private List<Activity> activities = new List<Activity>();

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
    }

    public string ActivityName
    {
        get
        {
            return activityName;
        }

        set
        {
            activityName = value;
        }
    }

    public static Manager GetInstance()
    {

        if (instance == null)
        {
            instance = new Manager();
        }

        return instance;

    }

    private Manager()
    {
        // initialize your game manager here. Do not reference to GameObjects here (i.e. GameObject.Find etc.)
        // because the game manager will be created before the objects
    }
}
