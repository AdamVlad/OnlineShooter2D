using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;

namespace Assets.Scripts.LobbyScene.ViewModel.Buttons
{
    [Binding]
    internal class LeaveGameButtonViewModel : MonoBehaviour
    {
        [Binding]
        public void OnClick()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}