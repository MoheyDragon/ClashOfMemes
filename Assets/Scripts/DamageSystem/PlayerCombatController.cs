using UnityEngine;
using Unity.Netcode;

public class PlayerCombatController : NetworkBehaviour
{
    [SerializeField] Transform ShootsSpawner;
    [SerializeField] GameObject Shot;
    [SerializeField] KeyCode shootKey;
    PlayerLifeStats playerStats;
    private void Start()
    {
        playerStats = GetComponent<PlayerLifeStats>();
    }
    private void Update()
    {
        if (!IsOwner) return;
        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Shot shot= Instantiate(Shot, ShootsSpawner).GetComponent<Shot>();
        shot.SetShotOwner(playerStats.GetPlayerId());

    }
}
