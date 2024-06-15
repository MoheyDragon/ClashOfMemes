using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;
[DisallowMultipleComponent]
public class ClientNetworkAnimator : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
