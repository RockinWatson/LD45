﻿using Assets.Scripts.Enums;
using Assets.Scripts.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private static Player _playerInstance;
        public static Player PlayerInstance { get { return _playerInstance; } }

        private bool _isShopLoaded = false;
        public bool IsShopLoaded { get { return _isShopLoaded; } set { _isShopLoaded = value; } }

        private CostumeEnum _costume;
        public CostumeEnum Costume { get { return _costume; } set { _costume = value; } }

        public PlayerData PlayerData { get; private set; }

        public Text CandyText;

        private bool EKeyPressed;

        private void OnEnable()
        {
            PlayerData = PlayerPersistence.LoadData();
        }

        private void OnDisable()
        {
            PlayerPersistence.SaveData(this);
        }

        private void Awake()
        {
            if (_playerInstance != null && _playerInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _playerInstance = this;
            }
        }

        private void Update()
        {
            CandyText.text = PlayerData.Candy.ToString();
            EKeyPressed = Input.GetKeyDown(KeyCode.E);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            //GOTO Shop
            if (EKeyPressed)
            {
                if (collision.gameObject.name == "ShopCollision")
                {
                    //Go To Shop
                    _isShopLoaded = true;
                }
                //Knock on Door for Candy
                if (collision.gameObject.name == "HouseCollision")
                {
                    //Get Candy
                    //PlayerData.Candy += 1;
                    //collision.gameObject.SetActive(false);

                    House house = collision.GetComponentInParent<House>();
                    house.TryToGetCandy();
                }
                //Knock on Door for Candy
                if (collision.gameObject.tag == "Candy")
                {
                    //Get Candy
                    Candy candy = collision.GetComponent<Candy>();
                    candy.SuckUpIntoPlayer();
                }
            }
        }

        public void AddCandy(int count = 1)
        {
            PlayerData.Candy += count;
        }
    }
}
