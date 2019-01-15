using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileControl : MonoBehaviour {

    public TextMeshProUGUI username;
    public TextMeshProUGUI gender;
    public TextMeshProUGUI age;
    public TextMeshProUGUI phonenumber;

    private void Start()
    {
        username.text = Manager.GetInstance().Username;
    }
}
