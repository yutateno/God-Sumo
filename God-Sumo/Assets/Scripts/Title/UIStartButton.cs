using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartButton : MonoBehaviour
{
    public void Click()
    {
        SoundManager.SEPlay(SoundManager.ESEAudioClipName.select);
        SceneManager.LoadScene("Difficulty Level");
    }
}
