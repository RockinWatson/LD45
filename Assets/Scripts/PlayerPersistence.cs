using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerPersistence
    {
        public static void SaveData(Player player)
        {
            PlayerPrefs.SetFloat("x", player.transform.position.x);
            PlayerPrefs.SetFloat("y", player.transform.position.y);
            PlayerPrefs.SetFloat("x", player.transform.position.z);
            PlayerPrefs.SetString("name", player.gameObject.name);
            PlayerPrefs.SetInt("candy", player.PlayerData.Candy);
        }

        public static PlayerData LoadData()
        {
            float x = PlayerPrefs.GetFloat("x");
            float y = PlayerPrefs.GetFloat("y");
            float z = PlayerPrefs.GetFloat("z");
            string name = PlayerPrefs.GetString("name");
            int candy = PlayerPrefs.GetInt("candy");

            PlayerData playerData = new PlayerData() {
                Location = new Vector3(x, y, z),
                Name = name,
                Candy = candy
            };

            return playerData;
        }
    }
}
