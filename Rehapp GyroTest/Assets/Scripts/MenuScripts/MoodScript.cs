using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoodScript : MonoBehaviour
{
    [SerializeField]
    private Sprite happyFace;
    [SerializeField]
    private Sprite superHappyFace;
    [SerializeField]
    private Sprite sadFace;
    [SerializeField]
    private Sprite superSadFace;
    [SerializeField]
    private Sprite welcomeFace;

    [TextArea(3, 10)]
    public string[] sentences;

    [SerializeField]
    private Image face;
    [SerializeField]
    private TextMeshProUGUI textMP;

    enum EnumMood
    {
        WELCOME,
        SUPERHAPPY,
        HAPPY,
        SAD,
        SUPERSAD
    }

    [SerializeField]
    private EnumMood _mood;

    // Start is called before the first frame update
    void Start()
    {
        switch (_mood)
        {
            case EnumMood.WELCOME:
                face.sprite = welcomeFace;
                textMP.text = sentences[0];
                break;

            case EnumMood.SUPERHAPPY:
                face.sprite = superHappyFace;
                textMP.text = sentences[1];
                break;
            case EnumMood.HAPPY:
                face.sprite = happyFace;
                textMP.text = sentences[2];
                break;
            case EnumMood.SAD:
                face.sprite = sadFace;
                textMP.text = sentences[3];
                break;
            case EnumMood.SUPERSAD:
                face.sprite = superSadFace;
                textMP.text = sentences[4];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
