﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneChange : MonoBehaviour {

    private const string LOGINSCREEN = "LoginScreen";
    private const string MAINSCREEN = "MainScreen";
    private const string ACTIVITYSCREEN = "ActivityScreen";
    private const string PROFILESCREEN = "ProfileScreen";
    private const string PHYSIOTERAPISTSCREEN = "PhysioterapistScreen";

    [SerializeField]
    private TextMeshProUGUI username;

    enum EnumChangeScene
    {
        LOGINSCREEN,
        MAINSCREEN,
        ACTIVITYSCREEN,
        PROFILESCREEN,
        PHYSIOTERAPISTSCREEN,

    }

    [SerializeField] private EnumChangeScene _scene;

    public void changeScene()
    {
        switch (_scene)
        {
            case EnumChangeScene.LOGINSCREEN:
                SceneManager.LoadScene(LOGINSCREEN);
                break;

            case EnumChangeScene.MAINSCREEN:
                SceneManager.LoadScene(MAINSCREEN);
                break;

            case EnumChangeScene.ACTIVITYSCREEN:
                SceneManager.LoadScene(ACTIVITYSCREEN);
                break;

            case EnumChangeScene.PROFILESCREEN:
                SceneManager.LoadScene(PROFILESCREEN);
                break;

            case EnumChangeScene.PHYSIOTERAPISTSCREEN:
                SceneManager.LoadScene(PHYSIOTERAPISTSCREEN);
                break;
        }
    }

    public void logIn()
    {
        Manager.GetInstance().Username = username.text;
        SceneManager.LoadScene(MAINSCREEN);
    }
}
