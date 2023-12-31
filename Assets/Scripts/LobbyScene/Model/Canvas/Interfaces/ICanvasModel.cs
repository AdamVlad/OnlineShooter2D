﻿namespace Assets.Scripts.LobbyScene.Model.Canvas.Interfaces
{
    internal interface ICanvasModel
    {
        ILoginPanel LoginPanel { get; }
        ICreateOrJoinRoomPanel CreateOrJoinRoomPanel { get; }
        IInsideRoomPanel InsideRoomPanel { get; }
        IPlayerListEntryPanel PlayerListEntryPanel { get; }
        IRoomListEntryPanel RoomListEntryPanel { get; }
        IButton StartGameButton{ get; }

        void SetActivePanel(string activePanel);
        void SetConnectionStatus(string text);
    }
}