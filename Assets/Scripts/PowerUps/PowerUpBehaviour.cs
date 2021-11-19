using UnityEngine;

public abstract class PowerUpBehaviour : MonoBehaviour
{
    protected abstract Evt GetPowerUpEvent();
    [SerializeField] public float powerUpDuration;
    private PowerUpManager powerUpManager;


    private void OnEnable()
    {
        GetPowerUpEvent().Subscribe(PowerUp);
        powerUpManager = GetComponent<PowerUpManager>();
    }


    private void OnDisable()
    {
        GetPowerUpEvent().UnSubscribe(PowerUp);
    }

    public void PowerUp()
    {
        powerUpManager.ActivatePowerUp(this);
    }


    public abstract void BeginPowerUp();
    public abstract void EndPowerUp();
}
