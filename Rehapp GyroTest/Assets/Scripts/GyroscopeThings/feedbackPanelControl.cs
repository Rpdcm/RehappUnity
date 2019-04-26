using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class feedbackPanelControl : MonoBehaviour
{
    public Sprite happyFace;
    public Sprite normalFace;
    public Sprite sadFace;
    public TimerController timer;
    public ObjectGyroMovement gyroController;
    private Image image;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        if(gyroController.finalResult == "Perfect")
        {
            image.sprite = happyFace;
            text.text = "¡Excelente trabajo!";
        }
        if (gyroController.finalResult == "Good")
        {
            image.sprite = normalFace;
            text.text = "Bien hecho";
        }
        if (gyroController.finalResult == "Bad")
        {
            image.sprite = sadFace;
            text.text = "Puedes hacerlo mejor";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
