using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarController : MonoBehaviour {

    private Scrollbar scrollbar;

    private void Start()
    {
        scrollbar = gameObject.GetComponent<Scrollbar>();
        scrollbar.value = 1;
    }
}
