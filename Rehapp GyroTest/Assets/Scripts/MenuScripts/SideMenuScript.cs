using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject _blackScreen;

    public Animator Anim
    {
        get
        {
            return anim;
        }

        set
        {
            anim = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void openSideMenu()
    {
        Anim.SetBool("IsOpen", true);
        Anim.SetBool("IsIdle", false);
    }

    public void closeSideMenu()
    {
        Anim.SetBool("IsOpen", false);
        _blackScreen.SetActive(false);
        Invoke("idleSideMenu", 0.5f);
    }

    public void idleSideMenu()
    {
        Anim.SetBool("IsIdle", true);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_blackScreen.GetComponent<Swipes>().SwipeLeft)
        {
            _blackScreen.GetComponent<Swipes>().SwipeLeft = false;
            closeSideMenu();
        }
    }

}
