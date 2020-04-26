using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UINormal : MonoBehaviour
{
    public void Click()
    {
        Manager.DifficultLevel = 2;
        SceneManager.LoadScene("Sumo Select");
    }
}
