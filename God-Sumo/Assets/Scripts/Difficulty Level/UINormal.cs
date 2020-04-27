using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UINormal : MonoBehaviour
{
    public void Click()
    {
        SoundManager.SEPlay(SoundManager.ESEAudioClipName.select);
        Manager.DifficultLevel = 2;
        SceneManager.LoadScene("Sumo Select");
    }
}
