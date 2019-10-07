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
            PlayerPrefs.SetInt("candy", player.PlayerData.Candy);
            PlayerPrefs.SetInt("candyScore", player.PlayerData.CandyScore);
            PlayerPrefs.SetInt("costume", player.PlayerData.Costume);
        }

        public static PlayerData LoadData()
        {
            float x = PlayerPrefs.GetFloat("x");
            float y = PlayerPrefs.GetFloat("y");
            float z = PlayerPrefs.GetFloat("z");
            int candy = PlayerPrefs.GetInt("candy");
            int candyScore = PlayerPrefs.GetInt("candyScore");
            int costume = PlayerPrefs.GetInt("costume");

            PlayerData playerData = new PlayerData() {
                Location = new Vector3(x, y, z),
                Candy = candy,
                CandyScore = candyScore,
                Costume = costume
            };

            return playerData;
        }
    }
}
