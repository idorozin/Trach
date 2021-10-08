using UnityEngine;


public class BulldozerPowerUpActivator : MonoBehaviour, PowerUpActivator
{
    public string powerUpName { get; set; }

    void Start()
    {
        powerUpName = "bulldozer";
    }
    public void ActivatePowerUp()
    {
        GameManager.Instance.ActivatePowerUp(powerUpName);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            ActivatePowerUp();
            Destroy(this.gameObject);
        }
    }
}