using UnityEngine;
using Unity.Netcode;
public class SessionManager : MonoBehaviour
{
    [SerializeField] GameObject EnterSessionCanvas;
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        Destroy(EnterSessionCanvas);
    }
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        Destroy(EnterSessionCanvas);
    }
}
