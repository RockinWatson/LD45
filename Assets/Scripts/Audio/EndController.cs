using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{

    public AudioSource storyMusic;
    public AudioSource startEnter;
    public AudioSource laugh;
    private bool _select() { return (Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.KeypadEnter)); }
    private bool restart;

    // Start is called before the first frame update
    void Awake()
    {
        InitAudio();
        StartCoroutine(MusicWait());
        restart = false;

    }

    // Update is called once per frame
    void Update()
    {
        if ((restart == false) && (_select()))
        {
            Debug.Log("Restart level");
            StartCoroutine(ChangeLevel());
        }
    }

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        storyMusic = audio[0];
        startEnter = audio[1];
        laugh = audio[2];

        startEnter.volume = .5f;
        storyMusic.volume = .7f;
        laugh.volume = 1f;

        laugh.Play();




    }

    IEnumerator MusicWait()
    {
        yield return new WaitForSeconds(1f);
        if (!storyMusic.isPlaying)
        {
            storyMusic.Play();
        }

    }

    IEnumerator ChangeLevel()
    {
        restart = true;
        startEnter.Play();
        storyMusic.Stop();
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene("TestScene");

    }
}
