using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectGyroMovement : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip correct;
    [SerializeField]
    private AudioClip exerciseComplete;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject buttonNextSet;
    private float xRotation = 0;
    private float yRotation = 0;
    private float zRotation = 0;
    private int repetitionCounter = 0;
    private bool repetitionCompleted = false;
    private int setCounter = 0;
    private int set = 2;
    private float timePassed = 0;
    private bool isStabilized = false;
    public string finalResult;
    [SerializeField]
    private GameObject buttonCalibrated;
    [SerializeField]
    private GameObject messageCalibration;
    [SerializeField]
    private GameObject progressCalibration;
    [SerializeField]
    private GameObject progressCalibrationFather;
    bool flag = false;
    bool secondFlag = false;
    private float secondsToCalibrate = 5;
    private float progressValue = 0;
    private int safeZoneA = 0;
    private int safeZoneB = 0;
    private bool introductionComplete = false;
    private bool finalFlag = false;
    private bool wrongXPosition = false;
    private bool wrongYPosition = false;
    [SerializeField]
    private GameObject endPanel;
    private bool stateOne = false;
    private bool stateTwo = false;
    private bool stateThree = false;
    private bool stateFlag = false;
    private float errorsCont = 0;
    private bool errorFlag = false;
    private bool repetitiveErrorFlag = false;
    private int repetitions = 2;
    private bool setChangeFlag = false;
    public GameObject X;
    public GameObject Y;
    public GameObject Z;
    public GameObject errorsText;
    private int yAxis;
    private bool yErrorFlag = false;
    private completeActivity completeActivityScript;
    private bool exerciseStarted = false;

    enum EnumExercises
    {
        ARMEXERCISE,
        LEGEXERCISE,
        SHOULDEREXERCISE
    }

    [SerializeField] private EnumExercises _exercises;

    public bool IsStabilized
    {
        get
        {
            return isStabilized;
        }

        set
        {
            isStabilized = value;
        }
    }

    public bool IntroductionComplete
    {
        get
        {
            return introductionComplete;
        }

        set
        {
            introductionComplete = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        completeActivityScript = GetComponent<completeActivity>();
    }

    // Update is called once per frame
    void Update()
    {

        Quaternion deviceRotation = DeviceRotation.Get();
        transform.rotation = deviceRotation;
        if (Mathf.Abs(xRotation - transform.eulerAngles.x) > 1)
        {
            xRotation = Mathf.Round(transform.eulerAngles.x);
        }
        if (Mathf.Abs(yRotation - transform.eulerAngles.y) > 1)
        {
            yRotation = Mathf.Round(transform.eulerAngles.y);
        }
        if (Mathf.Abs(zRotation - transform.eulerAngles.z) > 1)
        {
            zRotation = Mathf.Round(transform.eulerAngles.z);
        }

        X.GetComponent<TextMeshProUGUI>().text = "X = " + xRotation;
        Y.GetComponent<TextMeshProUGUI>().text = "Y = " + yRotation;
        Z.GetComponent<TextMeshProUGUI>().text = "Z = " + zRotation;
        errorsText.GetComponent<TextMeshProUGUI>().text = "Errores = " + errorsCont;

        if (!isStabilized)
        {
            startCalibration();

            if (xRotation > 88 && xRotation < 91)
            {
                timePassed += Time.deltaTime;
                progressValue = timePassed / secondsToCalibrate;
                if (progressValue > 1)
                {
                    progressValue = 1;
                }
                progressCalibration.GetComponent<Image>().fillAmount = progressValue;

                if (timePassed > secondsToCalibrate)
                {
                    endCalibration();
                }
            }
            else
            {
                timePassed = 0;
                progressCalibration.GetComponent<Image>().fillAmount = 0;
            }
        }


        if (IntroductionComplete)
        {
            switch (_exercises)
            {
                case EnumExercises.ARMEXERCISE:

                    if (repetitionCounter < 3)
                    {
                        if (xRotation <= 45)
                        {
                            if (!repetitionCompleted)
                            {
                                _audioSource.clip = correct;
                                _audioSource.Play();
                                repetitionCompleted = true;
                                repetitionCounter++;
                            }

                        }

                        if (xRotation >= 90)
                        {
                            if (repetitionCompleted)
                            {
                                _audioSource.clip = correct;
                                _audioSource.Play();
                                repetitionCompleted = false;
                            }
                        }
                    }
                    else
                    {
                        _audioSource.clip = exerciseComplete;
                        _audioSource.Play();
                        //feedback
                    }
                    break;

                case EnumExercises.SHOULDEREXERCISE:

                    if (setCounter < set)
                    {
                        if (repetitionCounter < repetitions)
                        {

                            if (xRotation > 15 && xRotation < 300)
                            {
                                wrongXPosition = true;
                            }
                            else
                            {
                                wrongXPosition = false;
                            }

                            if (yRotation > safeZoneA || yRotation < safeZoneB)
                            {
                                wrongYPosition = true;
                            }
                            else
                            {
                                wrongYPosition = false;
                            }


                            if (zRotation >= 177 && zRotation <= 181)
                            {
                                firstStateCompleted();
                            }

                            if (zRotation >= 88 && zRotation <= 91)
                            {
                                secondStateCompleted();
                            }

                            if ((zRotation >= 0 && zRotation <= 2) || (zRotation >= 357 && zRotation <= 360))
                            {
                                thirdStateCompleted();
                            }

                            wrongDirectionError();

                        }
                        else
                        {
                            nextSet();
                        }
                    }
                    else
                    {
                        endOfActivity();
                    }

                    break;
            }
        }

    }

    public void getYAxis()
    {
        yAxis = (int)yRotation;
        if ((360 - yAxis) < 40)
        {
            safeZoneA = 40 - (360 - yAxis);
        }
        else
        {
            safeZoneA = yAxis + 40;
        }
        if ((yAxis - 40) < 0)
        {
            safeZoneB = (yAxis - 40) + 360;
        }
        else
        {
            safeZoneB = yAxis - 40;
        }
    }

    private void nextSet()
    {
        exerciseStarted = false;

        if (setCounter != (set - 1))
        {
            if (!setChangeFlag)
            {
                buttonNextSet.SetActive(true);
                timer.SetActive(false);
                setChangeFlag = true;
            }
        }
        else
        {
            timer.SetActive(false);
            setCounter++;
        }
    }

    public void startNextSet()
    {
        setCounter++;
        repetitionCounter = 0;
        getYAxis();
        timer.SetActive(true);
        buttonNextSet.SetActive(false);
        setChangeFlag = false;
    }

    private void startCalibration()
    {
        if (!flag)
        {
            messageCalibration.SetActive(true);
            progressCalibrationFather.SetActive(true);
            flag = true;
        }
    }

    private void endCalibration()
    {
        if (!secondFlag)
        {
            _audioSource.clip = correct;
            _audioSource.Play();
            buttonCalibrated.SetActive(true);
            secondFlag = true;
        }
    }

    private void wrongDirectionError()
    {
        if (wrongXPosition && !errorFlag && exerciseStarted)
        {
            _audioSource.clip = exerciseComplete; //sonido temporal toca cambiarlo
            _audioSource.Play();
            errorsCont++;
            errorFlag = true;
        }

        if (!wrongXPosition && errorFlag)
        {
            errorFlag = false;
        }

        if (wrongYPosition && !yErrorFlag && exerciseStarted)
        {
            _audioSource.clip = exerciseComplete; //sonido temporal toca cambiarlo
            _audioSource.Play();
            errorsCont++;
            yErrorFlag = true;
        }

        if (!wrongYPosition && yErrorFlag)
        {
            yErrorFlag = false;
        }
    }

    private void firstStateCompleted()
    {
        if (!stateFlag)
        {
            if (stateOne && stateTwo && stateThree)
            {

                stateOne = false;
                stateTwo = false;
                stateThree = false;
                repetitionCounter++;
                stateFlag = true;
            }
        }

        if (stateTwo && stateOne && !stateThree && !repetitiveErrorFlag && exerciseStarted)
        {
            errorsCont++;
            repetitiveErrorFlag = true; // Bandera para saber si está subiendo y bajando el brazo  repetidas veces
        }

        if (!stateOne)
        {
            _audioSource.clip = correct;
            _audioSource.Play();
            stateOne = true;
        }

        exerciseStarted= true;
    }

    private void secondStateCompleted()
    {

        repetitiveErrorFlag = false;

        if (!stateTwo && stateOne && exerciseStarted)
        {
            _audioSource.clip = correct;
            _audioSource.Play();
            stateTwo = true;
        }


    }

    private void thirdStateCompleted()
    {
        if (!stateThree && stateTwo && stateOne && exerciseStarted)
        {
            _audioSource.clip = correct;
            _audioSource.Play();
            stateFlag = false;
            stateThree = true;
        }
    }

    private void endOfActivity()
    {
        if (!finalFlag)
        {
            _audioSource.clip = exerciseComplete;
            _audioSource.Play();
            if (errorsCont < 3)
            {
                finalResult = "Perfect";
            }
            else if (errorsCont > 2 && errorsCont < 6)
            {
                finalResult = "Good";
            }
            else if (errorsCont > 5)
            {
                finalResult = "Bad";
            }
            //completeActivityScript.completeTheActivity();
            endPanel.SetActive(true);
            finalFlag = true;
        }
    }
}



