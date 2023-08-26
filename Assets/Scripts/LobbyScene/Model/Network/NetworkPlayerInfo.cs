using Assets.Scripts.LobbyScene.Model.Network.Interfaces;
using UnityEngine;

namespace Assets.Scripts.LobbyScene.Model.Network
{
    public class NetworkPlayerInfo : INetworkPlayerInfo
    {
        public string Name { get; set; }
        public const string PlayerLoadedLevel = "PlayerLoadedLevel";
        public const string IsAlive = "IsAlive";

        public static Color GetColor(int colorChoice)
        {
            switch (colorChoice)
            {
                case 0: return Color.red;
                case 1: return Color.green;
                case 2: return Color.blue;
                case 3: return Color.yellow;
                case 4: return Color.cyan;
                case 5: return Color.grey;
                case 6: return Color.magenta;
                case 7: return Color.white;
            }

            return Color.black;
        }
    }
}