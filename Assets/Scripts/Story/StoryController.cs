using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour

{
    private bool _select() { return (Input.GetKeyDown(KeyCode.Space)); }
    private bool _right() { return (Input.GetKeyDown(KeyCode.RightArrow)); }
    private bool isStory;

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
    }

    // Update is called once per frame
    void Update()
    {
        CardSelect();

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
            }
        }
    }
}
