using System;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class SoundManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static SoundManager Instance { get; private set; }

    [Header("BGM")]
    [SerializeField]
    private AudioClip bgmTitle;   //タイトルbgm

    [SerializeField]
    private AudioClip bgmGame;  //ゲームbgm

    [Header("効果音")]
    [SerializeField]
    private AudioClip seJump;         // ジャンプ音

    [SerializeField]
    private AudioClip seItem;         // アイテム取得音

    [SerializeField]
    private AudioClip seStomp;        // 踏みつけ音

    [SerializeField]
    private AudioClip seGameOver;     // ゲームオーバー音

    [SerializeField]
    private AudioClip seClear;        // クリア音

    [Header("音量設定")]
    [SerializeField]
    private float bgmVolume = 0.5f; //bgm音量

    [SerializeField]
    private float seVolume = 1.0f; //効果音音量

    // AudioSourve Component
    private AudioSource bgmSource;
    private AudioSource seSource;

    void Awake()
    {
        // シングルトンパターン
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetupAudioSources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // <summary>
    // AudioSource２つ作成
    // </summary>
    private void SetupAudioSources()
    {
        // bgmヨウのAudioSource
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;
        bgmSource.playOnAwake = false;

        // 効果音用の以下同文
        seSource = gameObject.AddComponent<AudioSource>();
        seSource.loop = false;
        seSource.volume = seVolume;
        seSource.playOnAwake = false;
    }


    // <summary>
    // bgmを再生する
    //</summary> 
    public void PlayBGM(String bgmName)
    {
        AudioClip clip = null;

        switch (bgmName)
        {
            case "title":
                clip = bgmTitle;
                break;

            case "game":
                clip = bgmGame;
                break;
        }

        if (clip != null && bgmSource.clip != clip)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    // <summary>
    // bgmを停止する
    // </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    //<summary> 
    // 効果音を再生する
    // </summary>
    public void PlaySE(string seName)
    {
        AudioClip clip = null;

        switch (seName)
        {
            case "jump":
                clip = seJump;
                break;
            case "item":
                clip = seItem;
                break;
            case "stomp":
                clip = seStomp;
                break;
            case "gameover":
                clip = seGameOver;
                break;
            case "clear":
                clip = seClear;
                break;
        }

        if (clip != null)
        {
            // PlayOnShot
            seSource.PlayOneShot(clip, seVolume);
        }
    }

}
