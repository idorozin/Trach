

using UnityEngine;

public interface PowerUpActivator
{
    string powerUpName { get; set; }
    void ActivatePowerUp();
    void OnTriggerEnter(Collider other);
}
