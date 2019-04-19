using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileControl : MonoBehaviour {

    public TextMeshProUGUI username;
    public TextMeshProUGUI email;
    public TextMeshProUGUI role;

    private void Start()
    {
        username.text = Manager.GetInstance().Username;
        email.text = Manager.GetInstance().UserEmail;

        switch (Manager.GetInstance().User_role_id)
        {
            case "1":
                role.text = "Paciente";
                break;
            case "2":
                role.text = "Fisioterapeuta";
                break;
            case "3":
                role.text = "Empresa";
                break;
        }
    }
}
