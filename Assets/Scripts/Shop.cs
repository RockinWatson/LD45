using Assets.Scripts.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        public GameObject ShopMenuUI;

        private PlayerData _player;
        private bool _shopLoaded;

        public GameObject[] ShopItemList;
        private int _shopIndex = 0;

        private void Update()
        {
            if (Player.PlayerInstance.IsShopLoaded)
            {
                Pause();
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Debug.Log("MoveRight!!");
                    if (_shopIndex < ShopItemList.Length)
                    {
                        _shopIndex++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (_shopIndex > 0)
                    {
                        _shopIndex--;
                        if (_shopIndex == 0)
                        {
                            _shopIndex = 0;
                        }
                    }
                }
                Button btn = GetChildGameObject(ShopItemList[_shopIndex], "Button");
                btn.Select();
                btn.OnSelect(null);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && Player.PlayerInstance.IsShopLoaded)
            {
                Resume();               
            }
        }

        private Button GetChildGameObject(GameObject gObject, string name) {
            Button[] ts = gObject.transform.GetComponentsInChildren<Button>();
            foreach (Button t in ts) {
                if (t.gameObject.name == name) return t;
            }
            return null;
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
