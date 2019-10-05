using Assets.Scripts.Objects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public PlayerData PlayerData { get; private set; }

        private void OnEnable()
        {
            PlayerData = PlayerPersistence.LoadData();
        }

        private void OnDisable()
        {
            PlayerPersistence.SaveData(this);
        }

        private void Update()
        {
            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            //GOTO Shop
            if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "ShopCollision")
            {
                //Go To Shop
                SceneManager.LoadScene("Shop");
            }
            //Knock on Door for Candy
            if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "")
            {

            }
        }
    }
}
