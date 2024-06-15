using UnityEngine;
using Unity.Netcode;
using Invector.vCharacterController;
public class PlayerLifeStats : NetworkBehaviour
{
    int playerId;
    float health;
    float speeed;
    float power;
    vThirdPersonMotor vThirdMotor;
    private void Start()
    {
        SetPlayerStat(0, 100, 5, 5);
        ChangeSpeed(speeed);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            LowerSpeed(0,4);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            LowerSpeed(10,5);
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
    }
    float initialSpeed;
    public void LowerSpeed(float targetSpeed,float duration)
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
    public void Death()
    {

    }
}
