using Assets.Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        public GameObject ShopMenuUI;
        public GameObject ShopPointer;

        private PlayerData _player;
        private bool _shopLoaded;

        public GameObject[] ShopItemList;
        private int totalItems;
        private int _shopIndex = 0;

        private float yOffset = -250f;

        public Sprite[] SpriteList;
        public Animator PlayerAnimator;
        public SpriteRenderer PlayerSpriteRend;     

        private List<int> _usedShopItems = new List<int>();

        private int _ghostCostumeCost = 100;
        private int _princessCostumeCost = 200;
        private int _dinosaurCostumeCost = 300;
        private int _bucketUpgradeCost = 40;
        private int _bladesUpgradeCost = 100;
        private int _maskUpgradeCost = 25;
        private int _glovesUpgradeCost = 100;
        private int _hatUpgradeCost = 125;

        private RuntimeAnimatorController _ghostAnimatorController;

        private void Start()
        {
            totalItems = ShopItemList.Length - 1;
            _ghostAnimatorController = (RuntimeAnimatorController)Resources.Load("TaylorArt/GhostIdle_000");
        }

        private void Update()
        {
            
            if (Player.PlayerInstance.IsShopLoaded)
            {
                Pause();
                SetPointer(_shopIndex);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _shopIndex++;
                    if (_shopIndex >= totalItems)
                    {
                        _shopIndex = totalItems;
                    }                   
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    _shopIndex--;
                    if (_shopIndex <= 0)
                    {
                        _shopIndex = 0;
                    }
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!_usedShopItems.Contains(_shopIndex))
                    {
                        //Add Item To Player
                        if (_shopIndex >= 0 && _shopIndex <= 2)
                        {
                            //Add Costume sprite to player
                            SetSpriteCostume(_shopIndex);
                            _usedShopItems.Add(_shopIndex);
                        }
                        else
                        {
                            //Add Upgrade game object to Player
                            AddUpgradeToPlayer(_shopIndex);
                            _usedShopItems.Add(_shopIndex);
                        }
                    }
                }             
            }


            //Leave Shop
            if (Input.GetKeyDown(KeyCode.Escape) && Player.PlayerInstance.IsShopLoaded)
            {
                Resume();               
            }
        }

        public void SetSpriteCostume(int index) {
            switch (index)
            {
                case 0:
                    if (Player.PlayerInstance.PlayerData.Candy >= 0)
                    {
                        PlayerSpriteRend.sprite = SpriteList[0];
                        PlayerAnimator.runtimeAnimatorController = _ghostAnimatorController;
                    }                    
                    break;
                case 1:
                    if (Player.PlayerInstance.PlayerData.Candy >= _princessCostumeCost)
                    {
                        PlayerSpriteRend.sprite = SpriteList[1];
                    }                   
                    break;
                case 2:
                    if (Player.PlayerInstance.PlayerData.Candy >= _dinosaurCostumeCost)
                    {
                        PlayerSpriteRend.sprite = SpriteList[2];
                    }                    
                    break;
                default:
                    break;
            }
        }

        public void AddUpgradeToPlayer(int index) {
            switch (index)
            {
                case 3:
                    if (Player.PlayerInstance.PlayerData.Candy >= _bucketUpgradeCost)
                    {
                        //Add Bucket to GameObject
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetPointer(int listItem) {
            ShopPointer.transform.position = new Vector3(
                            ShopItemList[listItem].transform.position.x,
                            ShopItemList[listItem].transform.position.y + yOffset);
        }

        public void Resume() {
            ShopMenuUI.SetActive(false);
            Time.timeScale = 1f;
            Player.PlayerInstance.IsShopLoaded = false;
        }

        public void Pause() {
            ShopMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
