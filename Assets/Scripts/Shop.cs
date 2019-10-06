using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        public GameObject ShopMenuUI;

        private PlayerData _player;
        private bool _shopLoaded;

        private void Update()
        {
            if (Player.PlayerInstance.IsShopLoaded)
            {
                Pause();
            }
            if (Input.GetKeyDown(KeyCode.Escape) && Player.PlayerInstance.IsShopLoaded)
            {
                Resume();               
            }
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
