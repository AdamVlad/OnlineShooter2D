﻿namespace Assets.Scripts.LobbyScene.Model.Network.Interfaces
{
    internal interface INetworkRoomInfo
    {
        string CreatedRoomName { get; set; }
        string JoinedRoomName { get; set; }
    }
}