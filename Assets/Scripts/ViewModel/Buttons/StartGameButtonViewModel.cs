using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;

namespace Assets.Scripts.ViewModel.Buttons
{
    [Binding]
    internal class StartGameButtonViewModel : MonoBehaviour
    {
        [Binding]
        public void OnClick()
        {
            Debug.Log("Start game button clicked");

            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.LeaveLobby();
            }

            //PhotonNetwork.LoadLevel("BattleScene");
        }
    }
}