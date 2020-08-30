using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    private bool isMuted;
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
        CheckImageButton();
    }

    public void MutePressed() {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1:0);
        CheckImageButton();
    }

    void CheckImageButton() {
        if (isMuted) {
            but.image.sprite = OffSprite;
        } else {
            but.image.sprite = OnSprite;
        }
    }
}
