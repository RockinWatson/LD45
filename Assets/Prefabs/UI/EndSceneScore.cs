using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;
using Assets.Scripts.Objects;

public class EndSceneScore : MonoBehaviour
{
    [SerializeField]
    private Text _score = null;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData playerData = PlayerPersistence.LoadData();
        _score.text = playerData.CandyScore.ToString();
    }
}
