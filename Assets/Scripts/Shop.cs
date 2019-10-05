using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        private PlayerData _player;
        private int _candyAmount;

        private void Start()
        {
            _player = PlayerPersistence.LoadData();
            _candyAmount = _player.Candy;
        }

        private void Update()
        {
            
        }
    }
}
