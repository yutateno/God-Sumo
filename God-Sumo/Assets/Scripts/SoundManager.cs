using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 小さいゲームなのでテスト的に最初に全ての音をロードしておく
public class SoundManager : MonoBehaviour
{
    public AudioClip m_bgmBattle;
    public AudioClip m_bgmMenu;

    public AudioClip m_seSelect;
    public AudioClip m_seBattle;
    public AudioClip m_seWin;

    private AudioSource[] m_audioSource;

    private string nowScene;
    private string beforeScene;

    private void Start()
    {
        DontDestroyOnLoad(this);

        m_audioSource = GetComponents<AudioSource>();

        m_audioSource[0].loop = true;
        m_audioSource[0].clip = m_bgmMenu;
        m_audioSource[0].Play();

        beforeScene = SceneManager.GetActiveScene().name;
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
    }
}
