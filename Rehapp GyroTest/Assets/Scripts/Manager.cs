using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{

    private static Manager instance;
    private string username;
    private string activityName;
    private List<Activity> activities = new List<Activity>();
    public string userToken = " ";
    public List<friendRequestSuccess> friendRequests = new List<friendRequestSuccess>();
    public List<processRequestSuccess> processRequests = new List<processRequestSuccess>();
    public List<therapistRequestSuccess> therapistRequests = new List<therapistRequestSuccess>();
    public therapistRequestSuccess temporalTherapist;
    public string notificationTitle;
    public string notificationName;
    public int notificationListNumber;

    private string userId;
    private string userAge;
    private string userEmail;
    private string email_verified_at;
    private string user_role_id;
    private bool hasFriendRequests = false;




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

    public string UserId
    {
        get
        {
            return userId;
        }

        set
        {
            userId = value;
        }
    }

    public string UserAge
    {
        get
        {
            return userAge;
        }

        set
        {
            userAge = value;
        }
    }

    public string UserEmail
    {
        get
        {
            return userEmail;
        }

        set
        {
            userEmail = value;
        }
    }

    public string Email_verified_at
    {
        get
        {
            return email_verified_at;
        }

        set
        {
            email_verified_at = value;
        }
    }

    public string User_role_id
    {
        get
        {
            return user_role_id;
        }

        set
        {
            user_role_id = value;
        }
    }

    public bool HasFriendRequests
    {
        get
        {
            return hasFriendRequests;
        }

        set
        {
            hasFriendRequests = value;
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
