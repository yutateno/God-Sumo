using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static int m_difficultLevel = 0;
    private static int m_charaID = 0;

    public static int DifficultLevel
    {
        set { m_difficultLevel = value; }
        get { return m_difficultLevel; }
    }

    public static int CharaID
    {
        set { m_charaID = value; }
        get { return m_charaID; }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
