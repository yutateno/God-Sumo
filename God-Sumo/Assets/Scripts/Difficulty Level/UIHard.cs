using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHard : MonoBehaviour
{
    public void Click()
    {
        SoundManager.SEPlay(SoundManager.ESEAudioClipName.select);
        Manager.DifficultLevel = 3;
        SceneManager.LoadScene("Sumo Select");
    }
}
