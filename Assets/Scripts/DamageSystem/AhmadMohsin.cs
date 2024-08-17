using UnityEngine;
using Unity.Netcode;

public class AhmadMohsin : Shot
{
    protected override void OnHitPlayer(PlayerLifeStats player)
    {
        base.OnHitPlayer(player);
        player.CrazySpeed();
    }
}
public class Shot:NetworkBehaviour
{
    [SerializeField] protected float lifeTime;
    [SerializeField] protected float speed;
    protected float timeElapsed=0;
    protected int playerShootingId;
    private void Start()
    {
        transform.parent.DetachChildren();
    }
    public void SetShotOwner(int playerId)
    {
        playerShootingId= playerId;
    }
    protected void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed < lifeTime)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerLifeStats playerHit))
        {
            if(playerHit.GetPlayerId()!=playerShootingId)
            {
                OnHitPlayer(playerHit);
            }
        }
    }
    protected virtual void OnHitPlayer(PlayerLifeStats player)
    {
    }
}
