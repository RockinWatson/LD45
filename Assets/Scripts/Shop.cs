using Assets.Scripts.Objects;
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

        private void Start()
        {
            totalItems = ShopItemList.Length;
        }

        private void Update()
        {
            if (Player.PlayerInstance.IsShopLoaded)
            {
                Pause();
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
                SetPointer(_shopIndex);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && Player.PlayerInstance.IsShopLoaded)
            {
                Resume();               
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
