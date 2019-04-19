using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _blackScreen;
    private GameObject _sideMenu;

    // Start is called before the first frame update
    void Start()
    {
        _blackScreen.SetActive(false);
        _sideMenu = GameObject.FindGameObjectWithTag("SideMenu");
        _sideMenu.SetActive(false);
    }

    public void openSideMenu()
    {
        _sideMenu.SetActive(true);
        _blackScreen.SetActive(true);
        _sideMenu.GetComponent<SideMenuScript>().openSideMenu();
    }
}
