using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class PlayerData
    {
        public Vector3 Location { get; set; }
        public int Candy { get; set; } = 0;
        public int CandyScore { get; set; } = 0;
        public int Costume { get; set; } = 0;
        public List<bool> EarnedShopItems { get; set; } = null;
    }
}
