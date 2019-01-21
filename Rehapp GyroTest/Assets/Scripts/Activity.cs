using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity {

    private bool completed;
    private string calification;
    private string nombre;

    public Activity (bool completed, string calification, string nombre)
    {
        this.calification = calification;
        this.completed = completed;
        this.nombre = nombre;
    }
	
}
