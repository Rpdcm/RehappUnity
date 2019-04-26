using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private Sprite pauseSprite;
    [SerializeField]
    private Sprite playSprite;
    [SerializeField]
    private PanelVideoController panelController;
    private Image image;
    private bool paused = false;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = pauseSprite;

    }

    public void pauseAndPlay()
    {
        panelController.time = 0;
        if (!paused)
        {
            paused = true;
            image.sprite = playSprite;
            videoPlayer.Pause();
        }
        else
        {
            paused = false;
            image.sprite = pauseSprite;
            videoPlayer.Play();
        }
    }

}