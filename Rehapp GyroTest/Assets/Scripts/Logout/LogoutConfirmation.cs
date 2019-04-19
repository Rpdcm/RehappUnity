using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutConfirmation : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreen2;
    [SerializeField]
    private GameObject confirmationPanel;

    public void logout()
    {
        //Logout
    }

    public void cancelLogout()
    {
        blackScreen2.SetActive(false);
        confirmationPanel.SetActive(false);
    }

    public void openConfirmationPanel()
    {
        blackScreen2.SetActive(true);
        confirmationPanel.SetActive(true);
    }
}
