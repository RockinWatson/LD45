using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour

{
    public AudioSource storyMusic;
    public AudioSource startEnter;

    private bool _select() { return (Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.KeypadEnter)); }
    private bool _right() { return (Input.GetKeyDown(KeyCode.RightArrow)); }
    private bool _left() { return (Input.GetKeyDown(KeyCode.LeftArrow)); }
    private bool isStory;
    private bool nextLevel;

    private Vector3 cardPos;
    private Vector3 cardHidePos;
    private GameObject card1;
    private GameObject card2;
    private GameObject card3;
    private GameObject card4;
    private GameObject card5;
    private GameObject card6;
    private GameObject card7;

    private Scene _activeScene;

    // Start is called before the first frame update
    void Awake()
    {
        InitAudio();
        cardPos = new Vector3(0, 0, 0);
        cardHidePos = new Vector3(0, 50, 0);
        card1 = GameObject.Find("Card1");
        card2 = GameObject.Find("Card2");
        card3 = GameObject.Find("Card3");
        card4 = GameObject.Find("Card4");
        card5 = GameObject.Find("Card5");
        card6 = GameObject.Find("Card6");
        card7 = GameObject.Find("Card7");

        isStory = true;
        _activeScene = SceneManager.GetActiveScene();
        nextLevel = true;
    }

    // Update is called once per frame
    void Update()
    {
        CardSelect();

        if ((nextLevel == false) && (_select()))
        {
            Debug.Log("Change level");
            StartCoroutine(ChangeLevel());
        }

    }

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        storyMusic = audio[0];
        startEnter = audio[1];

        startEnter.volume = .5f;
        storyMusic.volume = .7f;

        if (!storyMusic.isPlaying)
        {
            storyMusic.Play();
        }
    }


    private void CardSelect()
    {
        if ((_right()) && (isStory))
        {
            if (card2.transform.position.x != cardPos.x)
            {
                card2.transform.position = cardPos;
                card1.transform.position = cardHidePos;
            }
            else if (card3.transform.position.x != cardPos.x)
            {
                card3.transform.position = cardPos;
                card2.transform.position = cardHidePos;
            }
            else if (card4.transform.position.x != cardPos.x)
            {
                card4.transform.position = cardPos;
                card3.transform.position = cardHidePos;
            }
            else if (card5.transform.position.x != cardPos.x)
            {
                card5.transform.position = cardPos;
                card4.transform.position = cardHidePos;
            }
            else if (card6.transform.position.x != cardPos.x)
            {
                card6.transform.position = cardPos;
                card5.transform.position = cardHidePos;
            }
            else if (card7.transform.position.x != cardPos.x)
            {
                card7.transform.position = cardPos;
                card6.transform.position = cardHidePos;
                nextLevel = false;
            }
        }
    }

    IEnumerator ChangeLevel()
    {
        nextLevel = true;
        startEnter.Play();
        storyMusic.Stop();
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene("TestScene");

    }

}
