using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 小さいゲームなのでテスト的に最初に全ての音をロードしておく
public class SoundManager : MonoBehaviour
{
    private bool m_isBGMChange;
    private bool m_isBGMVolumeUp;

    private static bool m_isSEDo;

    public AudioClip m_bgmBattle;
    public AudioClip m_bgmMenu;

    public AudioClip m_seSelect;
    public AudioClip m_seBattle;
    public AudioClip m_seWin;

    private static AudioSource[] m_audioSource;

    public enum ESEAudioClipName
    {
        select, battle, win
    }
    private static ESEAudioClipName m_seDoName;

    private string nowScene;
    private string beforeScene;

    private void Start()
    {
        DontDestroyOnLoad(this);

        m_audioSource = GetComponents<AudioSource>();

        m_isBGMChange = true;
        m_isBGMVolumeUp = true;

        m_audioSource[0].loop = true;
        m_audioSource[0].clip = m_bgmMenu;
        m_audioSource[0].volume = 0.25f;
        m_audioSource[0].Play();

        m_audioSource[1].loop = false;
        m_audioSource[1].clip = m_seSelect;
        m_audioSource[1].playOnAwake = true;

        beforeScene = "none";
        nowScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (nowScene != SceneManager.GetActiveScene().name)
        {
            nowScene = SceneManager.GetActiveScene().name;
        }


        if (beforeScene != nowScene)
        {
            beforeScene = SceneManager.GetActiveScene().name;

            m_isBGMChange = true;
        }


        if(m_isBGMChange)
        {
            if (m_isBGMVolumeUp)
            {
                BGMUp();
                if(!m_isBGMVolumeUp)
                {
                    m_isBGMChange = false;
                }
            }
            else
            {
                BGMDown();
            }
        }

        if(m_isSEDo)
        {
            SEPlayDo();
            m_isSEDo = false;
        }

        BGMVolumeChange_ForSE();
    }


    public static void SEPlay(ESEAudioClipName t_seAudio)
    {
        m_seDoName = t_seAudio;

        m_isSEDo = true;
    }


    private void SEPlayDo()
    {
        switch(m_seDoName)
        {
            case ESEAudioClipName.battle:
                m_audioSource[1].PlayOneShot(m_seBattle);
                break;

            case ESEAudioClipName.select:
                m_audioSource[1].PlayOneShot(m_seSelect);
                break;

            case ESEAudioClipName.win:
                m_audioSource[1].PlayOneShot(m_seWin);
                break;

            default:
                break;
        }
    }


    private void BGMSceneChange()
    {
        if (nowScene == "Title")
        {
            m_audioSource[0].Stop();
            m_audioSource[0].clip = m_bgmMenu;
            m_audioSource[0].Play();
        }
        else if (nowScene == "Difficulty Level")
        {
            m_audioSource[0].Stop();
            m_audioSource[0].clip = m_bgmBattle;
            m_audioSource[0].Play();
        }
        else if (nowScene == "Sumo Select")
        {
            m_audioSource[0].Stop();
            m_audioSource[0].clip = m_bgmMenu;
            m_audioSource[0].Play();
        }
        else if (nowScene == "Game")
        {
            m_audioSource[0].Stop();
            m_audioSource[0].clip = m_bgmBattle;
            m_audioSource[0].Play();
        }
    }
    
    //////////////////////////////////////////////////////////////一括したい、目的地のボリュームで変えれるようにしたい
    private void BGMUp()
    {
        if (m_audioSource[0].volume < 0.25f)
        {
            m_audioSource[0].volume += 0.001f;
        }
        else
        {
            m_audioSource[0].volume = 0.25f;
            m_isBGMVolumeUp = false;
        }
    }


    private void BGMDown()
    {
        if (m_audioSource[0].volume > 0.01f)
        {
            m_audioSource[0].volume -= 0.01f;
        }
        else
        {
            m_audioSource[0].volume = 0.0f;
            m_isBGMVolumeUp = true;

            BGMSceneChange();
        }
    }


    private void BGMVolumeChange_ForSE()
    {
        if (!m_isBGMChange)
        {
            if (m_audioSource[1].isPlaying)
            {
                if (m_audioSource[0].volume > 0.1f)
                {
                    m_audioSource[0].volume -= 0.01f;
                }
            }
            else
            {
                if (m_audioSource[0].volume < 0.25f)
                {
                    m_audioSource[0].volume += 0.01f;
                }
            }
        }
    }
    //////////////////////////////////////////////////////////////一括したい、目的地のボリュームで変えれるようにしたい
}
