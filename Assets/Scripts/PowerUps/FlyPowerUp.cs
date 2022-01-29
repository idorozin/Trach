
using UnityEngine;

public class FlyPowerUp : PowerUpBehaviour
{
    public Movement playerMovement;
    public Transform player;
    public CoinSpawner coinSpawner;
    [SerializeField]
    private GameObject wings;

    private float originalSpeed;

    protected override Evt GetPowerUpEvent()
    {
        return EventManager.Instance.onFlyPowerUp;
    }

    [SerializeField]
    private Grid grid;
    [SerializeField]
    private float multiplier = 2f;

    void Start()
    {
        grid.SetUpGrid();
        originalSpeed = playerMovement.forwardSpeed;
    }


    public override void BeginPowerUp()
    {
        player.position += new Vector3(0f, 4f, 0f);
        float xPos = -4f;
        float yPos = 4.5f;
        float zPos = player.position.z + 5f;
        playerMovement.forwardSpeed *= multiplier;
        Vector3 coinSpawnPosition = new Vector3(xPos, yPos, zPos);
        coinSpawner.SpawnCoinPattern(coinSpawnPosition, grid.grid);
        wings.SetActive(true);

    }

    public override void EndPowerUp()
    {
        wings.SetActive(false);
        player.position += new Vector3(0f, -4f, 0f);
        playerMovement.forwardSpeed = originalSpeed;
    }
}

