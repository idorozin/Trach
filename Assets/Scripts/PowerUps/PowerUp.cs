
using System.Collections;
using UnityEngine;

public abstract class PowerUpBehaviour : MonoBehaviour
{
    [SerializeField]
    private float powerUpDuration;

    public void PowerUp()
    {
        StartCoroutine(_PowerUp());
    }

    private IEnumerator _PowerUp()
    {
        BeginPowerUp();
        yield return new WaitForSeconds(4f);
        EndPowerUp();
    }

    protected abstract void BeginPowerUp();
    protected abstract void EndPowerUp();
}
