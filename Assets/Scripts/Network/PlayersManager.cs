using UnityEngine;
using Unity.Netcode;

public class PlayersManager : NetworkBehaviour
{
    int newPlayerId = -1;
    public static PlayersManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }
    public int GetNewPlayerId()
    {
        newPlayerId++;
        return newPlayerId;
    }
}
