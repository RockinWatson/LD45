using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    private float _candyCooldown = 15f;
    private float _candyTimer;

    [SerializeField]
    private int _candyCount = 5;

    [SerializeField]
    private GameObject _door = null;

    private bool _canGiveCandy = true;
    public bool CanGiveCandy()
    {
        return _canGiveCandy;
    }

    private void Awake()
    {
        _canGiveCandy = true;
        _candyTimer = 0f;
    }

    private void ResetTimer()
    {
        _candyTimer = _candyCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canGiveCandy)
        {
            _candyTimer -= Time.deltaTime;
            if (_candyTimer <= 0f)
            {
                _candyTimer = 0f;
                _canGiveCandy = true;
                _door.SetActive(true);
            }
        }
    }

    public void TryToGetCandy()
    {
        if(_canGiveCandy)
        {
            GetCandy();
        }
    }

    private void GetCandy()
    {
        //@TODO: Spawn Candy...
        for(int i = 0; i < _candyCount; ++i)
        {
            Vector3 spawnPos = _door.transform.position;
            Candy candy = CandyManager.Get().GetCandy(spawnPos);

            //@TODO: Apply mild random force downward from the house
            Rigidbody2D rigidBody = candy.GetComponent<Rigidbody2D>();
            Vector2 force = Vector2.down;
            force.x = Random.Range(-.5f, .5f);
            force *= 9f;
            rigidBody.AddForceAtPosition(force, candy.transform.position, ForceMode2D.Impulse);
            AudioController.doorbell.Play();
        }


        ResetTimer();
        _canGiveCandy = false;
        _door.SetActive(false);
    }
}
