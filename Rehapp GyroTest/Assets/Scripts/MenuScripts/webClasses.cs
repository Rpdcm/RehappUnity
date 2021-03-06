﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class webClasses
{
}
#region THERAPISTS

[Serializable]
public class therapistRootObject
{
    public therapistRequestSuccess[] data;

}

[Serializable]
public class therapistRequestSuccess
{
    public string id;
    public string name;
    public string age;
    public string description;
    public string email;
    public string email_verified_at;
    public string role_id;
}

#endregion

#region ACTIVITIES

[Serializable]
public class activitiesRootObject
{
    public activitiesRequestSuccess[] data;

}

[Serializable]
public class activitiesRequestSuccess
{
    public string id;
    public string date;
    public string rehabprocess_id;
    public activitiesList[] activities;
}

[Serializable]
public class activitiesList
{
    public string id;
    public string name;
    public string state;
    public string type;
    public string description;
    public string tool;
    public string date;
    public string order;
    public int duration;
    public int repetitions;
    public int sets;
    public string rehabprocess_id;
    public string user_id;
    public string creator_id;
    public string exercise_id;
    public string activities_orders_id;

}

#endregion


#region PROCESS

[Serializable]
public class processRootObject
{
    public processRequestSuccess[] data;

}

[Serializable]
public class processRequestSuccess
{
    public string id;
    public string name;
    public string state;
    public string description;
    public string creation_date;
    public string user_id;
    public string creator_id;
}

#endregion



#region FRIENDREQUESTS
[Serializable]
public class friendRootObject
{
    public friendRequestSuccess[] data;

}

[Serializable]
public class friendRequestUser
{
    public string id;
    public string name;
    public string age;
    public string email;
    public string email_verified_at;
    public string role_id;
}

[Serializable]
public class friendRequestSuccess
{
    public string id;
    public string state;
    public string date;
    public string user_id;
    public string friend_id;
    public friendRequestUser user;
}
#endregion
