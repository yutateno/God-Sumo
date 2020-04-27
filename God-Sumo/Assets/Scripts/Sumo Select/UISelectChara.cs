using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISelectChara : MonoBehaviour
{
    public void Click(int t_charaID)
    {
        SoundManager.SEPlay(SoundManager.ESEAudioClipName.select);
        Manager.CharaID = t_charaID;
        SceneManager.LoadScene("Game");
    }
}
