using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private bool isLevel;
    public static AudioSource levelMusic;
    public static AudioSource shopMusic;
    public static AudioSource select;
    public AudioSource wind1;
    public AudioSource wind2;
    public AudioSource wind3;
    public AudioSource wind4;
    public AudioSource wind5;
    public AudioSource laugh;
    public AudioSource scream1;
    public AudioSource scream2;
    public AudioSource crow1;
    public AudioSource crow2;
    public AudioSource crow3;
    public AudioSource whisper1;
    public AudioSource whisper2;
    public AudioSource whisper3;
    public static AudioSource doorbell;
    public static AudioSource candyPickup;
    public static AudioSource buy;

    private int windPicker;
    private bool windPlay;
    private bool crowPlay;
    private bool screamPlay;

    private float defaultVolume;

    private Scene _activeScene;

    // Use this for initialization
    void Awake()
    {

        isLevel = true;
        windPlay = false;
        crowPlay = false;
        screamPlay = false;
        InitAudio();
        _activeScene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        if ((!wind1.isPlaying) && (!wind2.isPlaying) && (!wind3.isPlaying) && (!wind4.isPlaying) && (!wind5.isPlaying))
        {
            PlayWind();
        }
        if ((!crow1.isPlaying) && (!crow2.isPlaying) && (!crow3.isPlaying) && crowPlay == false)
        {
            StartCoroutine(Crow());
        }
        if ((!scream1.isPlaying) && (!scream2.isPlaying) && (!laugh.isPlaying) && (!whisper1.isPlaying) && (!whisper2.isPlaying) && (!whisper3.isPlaying) && (screamPlay == false))
        {
            StartCoroutine(Scream());
        }

    }

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        levelMusic = audio[0];
        shopMusic = audio[1];
        select = audio[2];
        wind1 = audio[3];
        wind2 = audio[4];
        wind3 = audio[5];
        wind4 = audio[6];
        wind5 = audio[7];
        laugh = audio[8];
        scream1 = audio[9];
        scream2 = audio[10];
        crow1 = audio[11];
        crow2 = audio[12];
        crow3 = audio[13];
        whisper1 = audio[14];
        whisper2 = audio[15];
        whisper3 = audio[16];
        doorbell = audio[17];
        candyPickup = audio[18];
        buy = audio[19];

        levelMusic.volume = 1f;
        shopMusic.volume = .45f;
        select.volume = .4f;
        crow1.volume = .18f;
        crow2.volume = .18f;
        crow3.volume = .18f;
        laugh.volume = .5f;
        scream1.volume = .7f;
        scream2.volume = .9f;
        whisper1.volume = .4f;
        whisper2.volume = .4f;
        whisper3.volume = .4f;
        doorbell.volume = .5f;
        buy.volume = .5f;
        levelMusic.Play();
        levelMusic.loop = true;
        shopMusic.loop = true;
    }

    private void PlayWind()
    {
        windPicker = Random.Range(1, 5);
        switch (windPicker)
        {
            case 1:
                wind1.Play();

                break;
            case 2:
                wind2.Play();

                break;
            case 3:
                wind3.Play();

                break;
            case 4:
                wind4.Play();

                break;
            case 5:
                wind5.Play();

                break;
            default:
                break;
        }
    }

    IEnumerator Crow()
    {
        crowPlay = true;
        float timer = Random.Range(15f, 40f);
        yield return new WaitForSeconds(timer);
        int crowPicker = Random.Range(1, 3);
            switch (crowPicker)
            {
                case 1:
                    crow1.Play();
                    break;
                case 2:
                    crow2.Play();
                    break;
                case 3:
                    crow3.Play();
                    break;
                default:
                    break;
            }

        crowPlay = false;
    }

    IEnumerator Scream()
    {
        screamPlay = true;
        float timer = Random.Range(10f, 30f);
        yield return new WaitForSeconds(timer);
        int screamPicker = Random.Range(1, 6);
        switch (screamPicker)
        {
            case 1:
                scream1.Play();
                break;
            case 2:
                scream2.Play();
                break;
            case 3:
                laugh.Play();
                break;
            case 4:
                whisper1.Play();
                break;
            case 5:
                whisper2.Play();
                break;
            case 6:
                whisper3.Play();
                break;
            default:
                break;
        }

        screamPlay = false;
    }

}