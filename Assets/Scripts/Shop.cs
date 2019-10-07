using Assets.Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        public const int TOTAL_SHOP_ITEMS = 8;
        private List<int> _usedShopItems = new List<int>();
        public List<int> GetEarnedShopItems() { return _usedShopItems; }
        public void SetEarnedShopItems(List<int> items) { _usedShopItems = items; }

        private int _ghostCostumeCost = 100;
        private int _princessCostumeCost = 200;
        private int _dinosaurCostumeCost = 300;
        private int _bucketUpgradeCost = 40;
        private int _bladesUpgradeCost = 100;
        private int _maskUpgradeCost = 25;
        private int _glovesUpgradeCost = 100;
        private int _hatUpgradeCost = 125;

        [SerializeField]
        private Text _candyText = null;
        [SerializeField]
        private Text _timeLeftText = null;

        [SerializeField]
        private List<Text> _costTexts = null;

        static private Shop _instance = null;
        static public Shop Get() { return _instance; }

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            totalItems = ShopItemList.Length - 1;
        }

        private void Update()
        {
            if (Player.PlayerInstance.IsShopLoaded)
            {
                Pause();

                if (!AudioController.shopMusic.isPlaying)
                {
                    AudioController.shopMusic.Play();
                }

                UpdateUI();

                UpdatePointer();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    MakeSelection();
                }             
            }


            //Leave Shop
            if (Input.GetKeyDown(KeyCode.Escape) && Player.PlayerInstance.IsShopLoaded)
            {
                Resume();
            }
        }

        private void UpdateUI()
        {
            _candyText.text = Player.PlayerInstance.PlayerData.Candy.ToString();
            _timeLeftText.text = Player.PlayerInstance.GetGamerTimer().ToString("0.0");

            foreach (int index in _usedShopItems)
            {
                _costTexts[index].text = "-X-";
            }
        }

        private void UpdatePointer()
        {
            SetPointer(_shopIndex);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _shopIndex++;
                if (_shopIndex <= totalItems)
                {
                    AudioController.select.Play();
                }
                if (_shopIndex >= totalItems)
                {
                    _shopIndex = totalItems;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _shopIndex--;
                if (_shopIndex >= 0)
                {
                    AudioController.select.Play();
                }
                if (_shopIndex <= 0)
                {
                    _shopIndex = 0;
                }
            }
        }

        private void MakeSelection()
        {
            //if (!_usedShopItems.Contains(_shopIndex))
            {
                //Add Item To Player
                if (_shopIndex >= 0 && _shopIndex <= 2)
                {
                    if (!_usedShopItems.Contains(_shopIndex))
                    {
                        //Add Costume sprite to player
                        //CostumeManager.Get().SetCostume(_shopIndex);
                        //SetSpriteCostume(_shopIndex);
                        TryToBuyAndSetCostume(_shopIndex);
                    }
                    else
                    {
                        int currentCostume = CostumeManager.Get().GetCurrentCostume();
                        if (currentCostume == _shopIndex + 1)
                        {
                            SetCostume(0);
                        }
                        else
                        {
                            SetCostume(_shopIndex + 1);
                        }
                        AudioController.buy.Play();
                    }
                }
                else
                {
                    if (!_usedShopItems.Contains(_shopIndex))
                    {
                        //Add Upgrade game object to Player
                        AddUpgradeToPlayer(_shopIndex);
                    } else
                    {
                        SetUpgrade(_shopIndex - 3);
                        AudioController.buy.Play();
                    }
                }
            }
        }

        private void TryToBuyAndSetCostume(int index)
        {
            Player player = Player.PlayerInstance;
            int candyCount = player.PlayerData.Candy;
            int candyCost = 0;
            switch (index)
            {
                case 0:
                    if(candyCount > _ghostCostumeCost)
                    {
                        candyCost = _ghostCostumeCost;
                    }
                    break;
                case 1:
                    if (candyCount > _princessCostumeCost)
                    {
                        candyCost = _princessCostumeCost;
                    }
                    break;
                case 2:
                    if (candyCount > _dinosaurCostumeCost)
                    {
                        candyCost = _dinosaurCostumeCost;
                    }
                    break;
            }
            if(candyCost > 0)
            {
                SetCostume(index+1);
                player.PlayerData.Candy -= candyCost;
                _usedShopItems.Add(index);
                AudioController.buy.Play();
            }
        }

        private void SetCostume(int index)
        {
            CostumeManager.Get().SetCostume(index);
        }

        public void AddUpgradeToPlayer(int index) {
            Player player = Player.PlayerInstance;
            int candyCount = player.PlayerData.Candy;
            int candyCost = 0;
            switch (index)
            {
                case 3:
                    if (candyCount >= _bucketUpgradeCost)
                    {
                        candyCost = _bucketUpgradeCost;
                    }
                    break;
                case 4:
                    if (candyCount >= _bladesUpgradeCost)
                    {
                        candyCost = _bladesUpgradeCost;
                    }
                    break;
                case 5:
                    if (candyCount >= _maskUpgradeCost)
                    {
                        candyCost = _maskUpgradeCost;
                    }
                    break;
                case 6:
                    if (candyCount >= _glovesUpgradeCost)
                    {
                        candyCost = _glovesUpgradeCost;
                    }
                    break;
                case 7:
                    if (candyCount >= _hatUpgradeCost)
                    {
                        candyCost = _hatUpgradeCost;
                    }
                    break;
                default:
                    break;
            }
            if (candyCost > 0)
            {
                SetUpgrade(index - 3);
                player.PlayerData.Candy -= candyCost;
                _usedShopItems.Add(index);
                AudioController.buy.Play();
            }
        }

        private void SetUpgrade(int index)
        {
            CostumeManager.Get().SetUpgrade(index);
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
            AudioController.shopMusic.mute = true;
            AudioController.levelMusic.mute = false;
        }

        public void Pause() {
            ShopMenuUI.SetActive(true);
            Time.timeScale = 0f;
            AudioController.shopMusic.mute = false;
            AudioController.levelMusic.mute = true;
        }
    }
}
