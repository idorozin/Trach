
using UnityEngine;

public class FlyPowerUp : PowerUpBehaviour
{
    public Transform player;
    public CoinSpawner coinSpawner;
    [SerializeField]
    private GameObject wings; 

    protected override Evt GetPowerUpEvent()
    {
        return EventManager.Instance.onFlyPowerUp;
    }

    [SerializeField]
    private Grid grid;

    void Start()
    {
        grid.SetUpGrid();
    }


    public override void BeginPowerUp()
    {
        player.position += new Vector3(0f, 4f, 0f);
        float xPos = Random.Range(1f, 8f - grid.spacingX*(grid.cols-1));
        float yPos = 4.5f;
        float zPos = player.position.z + 5f;
        Vector3 coinSpawnPosition = new Vector3(xPos, yPos, zPos);
        coinSpawner.SpawnCoinPattern(coinSpawnPosition, grid.grid);
        wings.SetActive(true);

    }

    public override void EndPowerUp()
    {
        wings.SetActive(false);
        player.position += new Vector3(0f, -4f, 0f);
    }
}

