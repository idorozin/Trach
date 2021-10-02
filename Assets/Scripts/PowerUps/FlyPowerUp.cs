
using UnityEngine;

public class FlyPowerUp : PowerUpBehaviour
{
    public Transform player;
    
    protected override void BeginPowerUp()
    {
        player.position += new Vector3(0f, 4f, 0f);
    }

    protected override void EndPowerUp()
    {
        player.position += new Vector3(0f, -4f, 0f);
    }
}

