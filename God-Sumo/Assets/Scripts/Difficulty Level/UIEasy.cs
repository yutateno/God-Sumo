using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEasy : MonoBehaviour
{
    public void Click()
    {
        Manager.DifficultLevel = 1;
        SceneManager.LoadScene("Sumo Select");
    }
}
