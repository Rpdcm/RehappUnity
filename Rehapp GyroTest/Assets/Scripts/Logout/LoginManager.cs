using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI username;
    [SerializeField]
    private TextMeshProUGUI email;
    [SerializeField]
    private TextMeshProUGUI password;
    [SerializeField]
    private TextMeshProUGUI confirmPassword;
    [SerializeField]
    private TMP_Dropdown dropdown;
    [SerializeField]
    private GameObject userData;
    [SerializeField]
    private Sprite wrongUsername;
    [SerializeField]
    private Sprite wrongPassword;
    [SerializeField]
    private GameObject incorrectText;
    [SerializeField]
    private GameObject inputUsername;
    [SerializeField]
    private GameObject inputPassword;

    private int roleId = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void userRegister()
    {
        roleId = dropdown.value + 1;
        StartCoroutine(Register());
    }

    public void userLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Register()
    {
        Debug.Log(username.text);
        WWWForm form = new WWWForm();
        form.AddField("name", username.text.TrimEnd('\u200b'));
        form.AddField("email", email.text.TrimEnd('\u200b'));
        form.AddField("password", password.text.TrimEnd('\u200b'));
        form.AddField("c_password", confirmPassword.text.TrimEnd('\u200b'));
        form.AddField("role_id", roleId.ToString());

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

    IEnumerator Login()
    {

        WWWForm form = new WWWForm();
        form.AddField("email", email.text.TrimEnd('\u200b'));
        form.AddField("password", password.text.TrimEnd('\u200b'));


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/login", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                //if incorrectPasswordthings
                inputUsername.GetComponent<Image>().sprite = wrongUsername;
                inputPassword.GetComponent<Image>().sprite = wrongPassword;
                incorrectText.SetActive(true);
                incorrectText.GetComponent<TextMeshProUGUI>().text = "El nombre de usuario y/o contraseña son incorrectos";
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                rootObject stringToken = JsonUtility.FromJson<rootObject>(www.downloadHandler.text);
                Debug.Log(stringToken.success.token);
                Manager.GetInstance().userToken = "Bearer " + stringToken.success.token;
                userData.GetComponent<GetData>().getData();
                

            }
        }
    }



    [Serializable]
    public class rootObject
    {
        public Success success;

    }

    [Serializable]
    public class Success
    {
        public string token;

    }
}
