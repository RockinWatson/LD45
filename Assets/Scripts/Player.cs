using Assets.Scripts.Objects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public PlayerData PlayerData { get; private set; }

        public Text CandyText;

        private bool EKeyPressed;

        private void OnEnable()
        {
            PlayerData = PlayerPersistence.LoadData();
            CandyText.text = PlayerData.Candy.ToString();
        }

        private void OnDisable()
        {
            PlayerPersistence.SaveData(this);
        }

        private void Update()
        {
            CandyText.text = PlayerData.Candy.ToString();
            EKeyPressed = Input.GetKeyDown(KeyCode.E);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            //GOTO Shop
            if (EKeyPressed && collision.gameObject.name == "ShopCollision")
            {
                //Go To Shop
                SceneManager.LoadScene("Shop");
            }
            //Knock on Door for Candy
            if (EKeyPressed && collision.gameObject.name == "HouseCollision")
            {
                //Get Candy
                PlayerData.Candy += 1;
                collision.gameObject.SetActive(false);
            }
        }
    }
}
