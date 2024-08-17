using UnityEngine;
using Unity.Netcode;
using Invector.vCharacterController;
using TMPro;
public class PlayerLifeStats : NetworkBehaviour
{
    int playerId;
    float health;
    float speeed;
    float power;
    vThirdPersonMotor vThirdMotor;
    [SerializeField] TextMeshPro playerIdText;
    private void Start()
    {
        int  newPlayerId = PlayersManager.instance.GetNewPlayerId();
        SetPlayerStat(newPlayerId, 100, 5, 5);
        ChangeSpeed(speeed);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            CrazySpeed();
        }
    }
    public void SetPlayerStat(int playerId,float initialHealth,float speed,float power)
    {
        this.playerId = playerId;
        this.health = initialHealth;
        this.speeed = speed;
        this.power = power;
        initialSpeed = speed;
        vThirdMotor = GetComponent<vThirdPersonMotor>();
        playerIdText.text = playerId.ToString();
    }
    float initialSpeed;
    public void CrazySpeed()
    {
        ChangeSpeed(20,10);
    }
    public void ChangeSpeed(float targetSpeed,float duration)
    {
        ChangeSpeed(targetSpeed);
        Invoke(nameof(ReturnSpeed), duration);
    }
    private void ChangeSpeed(float newSpeed)
    {
        speeed = newSpeed;
        vThirdMotor.UpdateSpeed(newSpeed);
    }
    private void ReturnSpeed()
    {
        ChangeSpeed(initialSpeed);
    }

    public void LowerPower(float divider)
    {
        power = power / divider;
    }
    public void Damage(float damage) { 
        health -= damage;
        if(health<=0)
            Death();
    }
    public int GetPlayerId() { return playerId; }
    public void Death()
    {

    }
}
