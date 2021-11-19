
using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    private PowerUpBehaviour currentPowerUp;

    public void ActivatePowerUp(PowerUpBehaviour powerUpBehaviour)
    {
        if(currentPowerUp != null)
            currentPowerUp.EndPowerUp();
        currentPowerUp = powerUpBehaviour;
        timer.StartCountDown(powerUpBehaviour.powerUpDuration);
        StopAllCoroutines();
        StartCoroutine(_PowerUp(powerUpBehaviour));
    }
    
    private IEnumerator _PowerUp(PowerUpBehaviour powerUpBehaviour)
    {
        powerUpBehaviour.BeginPowerUp();
        yield return new WaitForSeconds(powerUpBehaviour.powerUpDuration);
        powerUpBehaviour.EndPowerUp();
        currentPowerUp = null;
    }
}
