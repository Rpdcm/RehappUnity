using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class SceneChange : MonoBehaviour {

    private const string LOGINSCREEN = "LoginScreen";
    private const string MAINSCREEN = "MainScreen";
    private const string ACTIVITYSCREEN = "ActivityScreen";
    private const string PROCESSSCREEN = "ProcessScreen";
    private const string PROFILESCREEN = "ProfileScreen";
    private const string PHYSIOTERAPISTSCREEN = "PhysioterapistScreen";
    private const string CURRENTACTIVITYSCREEN = "CurrentActivityScreen";
    private const string NOTIFICATIONSCREEN = "NotificationScreen";
    private const string CALENDARSCREEN = "CalendarScreen";
    private const string PROGRESS_SCREEN = "Progress_Screen";
    private const string TESTSCREEN = "TestScene";
    private const string EDITPROFILESCREEN = "ProfileEditScreen";
    private const string REGISTERSCREEN = "RegisterScreen";
    private const string CURRENTNOTIFICATIONSCREEN = "CurrentNotificationScreen";
    private const string PHISIOTERAPISTLISTSCREEN = "PhisiotherapistListScreen";
    private const string VIDEOSCREEN = "VideoScene";

    [SerializeField]
    private TextMeshProUGUI textData;
    [SerializeField]
    private GameObject gameObjectData;
    private int listPosition;


    enum EnumChangeScene
    {
        LOGINSCREEN,
        MAINSCREEN,
        ACTIVITYSCREEN,
        PROFILESCREEN,
        PHYSIOTERAPISTSCREEN,
        CURRENTACTIVITYSCREEN,
        NOTIFICATIONSCREEN,
        CALENDARSCREEN,
        PROGRESS_SCREEN,
        TESTSCREEN,
        EDITPROFILESCREEN,
        REGISTERSCREEN,
        CURRENTNOTIFICATIONSCREEN,
        PHISIOTERAPISTLISTSCREEN,
        PROCESSSCREEN,
        VIDEOSCREEN
    }

    [SerializeField] private EnumChangeScene _scene;

    public void changeScene()
    {
        switch (_scene)
        {
            case EnumChangeScene.LOGINSCREEN:
                SceneManager.LoadScene(LOGINSCREEN);
                break;

            case EnumChangeScene.VIDEOSCREEN:
                SceneManager.LoadScene(VIDEOSCREEN);
                break;

            case EnumChangeScene.PHISIOTERAPISTLISTSCREEN:
                SceneManager.LoadScene(PHISIOTERAPISTLISTSCREEN);
                break;

            case EnumChangeScene.PROCESSSCREEN:
                SceneManager.LoadScene(PROCESSSCREEN);
                break;


            case EnumChangeScene.REGISTERSCREEN:
                SceneManager.LoadScene(REGISTERSCREEN);
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
                listPosition = gameObjectData.GetComponent<therapistInfo>().listPosition;
                Manager.GetInstance().temporalTherapist = Manager.GetInstance().therapistRequests[listPosition];
                SceneManager.LoadScene(PHYSIOTERAPISTSCREEN);
                break;

            case EnumChangeScene.CURRENTACTIVITYSCREEN:
                Manager.GetInstance().temporalActivity = Manager.GetInstance().activitiesRequests[gameObjectData.GetComponent<activityInfo>().listPositionData].activities[gameObjectData.GetComponent<activityInfo>().listPositionActivity];
                SceneManager.LoadScene(CURRENTACTIVITYSCREEN);
                activityScreenData();
                break;
            case EnumChangeScene.NOTIFICATIONSCREEN:
                SceneManager.LoadScene(NOTIFICATIONSCREEN);
                break;
            case EnumChangeScene.CALENDARSCREEN:
                SceneManager.LoadScene(CALENDARSCREEN);
                break;
            case EnumChangeScene.PROGRESS_SCREEN:
                SceneManager.LoadScene(PROGRESS_SCREEN);
                break;
            case EnumChangeScene.TESTSCREEN:
                SceneManager.LoadScene(TESTSCREEN);
                break;
            case EnumChangeScene.EDITPROFILESCREEN:
                SceneManager.LoadScene(EDITPROFILESCREEN);
                break;
            case EnumChangeScene.CURRENTNOTIFICATIONSCREEN:
                Manager.GetInstance().notificationTitle = gameObjectData.GetComponent<notificationInfo>().notificationTitle;
                Manager.GetInstance().notificationName = gameObjectData.GetComponent<notificationInfo>().notificationFriendName;
                Manager.GetInstance().notificationListNumber = gameObjectData.GetComponent<notificationInfo>().listPosition;
                SceneManager.LoadScene(CURRENTNOTIFICATIONSCREEN);
                break;
        }
    }

    public void logIn()
    {
        //Manager.GetInstance().Username = textData.text;
        
        //SceneManager.LoadScene(MAINSCREEN);
    }

    public void userRegistration()
    {
        StartCoroutine(Register());
    }

    private void activityScreenData()
    {
        Manager.GetInstance().ActivityName = textData.text;
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "pedro");
        form.AddField("email", "pedroporsucasa@gmail.com");
        form.AddField("password", "junini123");
        form.AddField("c_password", "junini123");
        form.AddField("role_id", "2");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/register", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
