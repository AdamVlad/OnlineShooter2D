using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;

namespace Assets.Scripts.ViewModel.Buttons
{
    [Binding]
    internal class LeaveGameButtonViewModel : MonoBehaviour
    {
        [Binding]
        public void OnClick()
        {
            Debug.Log("Leave game button clicked");

            PhotonNetwork.LeaveRoom();
        }
    }
}