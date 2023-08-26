using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;

namespace Assets.Scripts.BattleScene.ViewModel
{
    [Binding]
    internal class BackToMenuButtonViewModel : MonoBehaviour
    {
        [Binding]
        public void OnClick()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}