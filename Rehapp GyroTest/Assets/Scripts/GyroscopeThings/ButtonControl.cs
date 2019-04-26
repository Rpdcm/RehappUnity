using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    private GameObject objectGyroscope;
    [SerializeField]
    private GameObject guidePicture;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject timer;
    public GameObject axis;
    [SerializeField]
    private GameObject secondPicture;



    public void startExercise()
    {
        
        objectGyroscope.SetActive(true);
        axis.SetActive(true);
        guidePicture.SetActive(false);
        gameObject.SetActive(false);

    }

    public void endCalibration()
    {
        if (objectGyroscope.GetComponent<ObjectGyroMovement>().IsStabilized && !objectGyroscope.GetComponent<ObjectGyroMovement>().IntroductionComplete)
        {
            secondPicture.SetActive(false);
            button.SetActive(false);
            axis.SetActive(false);
            gameObject.SetActive(false);
            objectGyroscope.GetComponent<ObjectGyroMovement>().IntroductionComplete = true;
            objectGyroscope.GetComponent<ObjectGyroMovement>().getYAxis();
            timer.SetActive(true);
        }

        if (!objectGyroscope.GetComponent<ObjectGyroMovement>().IsStabilized && !objectGyroscope.GetComponent<ObjectGyroMovement>().IntroductionComplete)
        {
            guidePicture.SetActive(false);
            secondPicture.SetActive(true);
            objectGyroscope.GetComponent<ObjectGyroMovement>().IsStabilized = true;
        }

    }

}
